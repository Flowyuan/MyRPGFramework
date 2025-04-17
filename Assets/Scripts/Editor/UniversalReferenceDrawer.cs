using UnityEditor;
using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

// 对所有使用 [SerializeReference] 的字段生效
[CustomPropertyDrawer(typeof(SerializeReference))] 
public class UniversalReferenceDrawer : PropertyDrawer
{
    private static Dictionary<Type, Type[]> _subTypeCache = new Dictionary<Type, Type[]>();

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        // 获取字段的实际类型（支持数组/List）
        Type fieldType = GetFieldType(property);

        // 绘制标签
        Rect labelRect = new Rect(position.x, position.y, EditorGUIUtility.labelWidth, position.height);
        EditorGUI.LabelField(labelRect, label);

        // 绘制值区域（显示当前类型+下拉菜单）
        Rect valueRect = new Rect(
            position.x + EditorGUIUtility.labelWidth,
            position.y,
            position.width - EditorGUIUtility.labelWidth,
            position.height
        );

        DrawTypeSelection(valueRect, property, fieldType);

        EditorGUI.EndProperty();
    }

    private void DrawTypeSelection(Rect position, SerializedProperty property, Type fieldType)
    {
        // 获取当前值
        object currentValue = property.managedReferenceValue;
        string currentTypeName = currentValue?.GetType().Name ?? "Null";

        // 显示下拉按钮
        if (EditorGUI.DropdownButton(position, new GUIContent(currentTypeName), FocusType.Keyboard))
        {
            GenericMenu menu = new GenericMenu();

            // 添加 "Null" 选项
            menu.AddItem(new GUIContent("Null"), currentValue == null, () =>
            {
                property.managedReferenceValue = null;
                property.serializedObject.ApplyModifiedProperties();
            });

            // 添加所有子类选项
            foreach (Type type in GetSubTypes(fieldType))
            {
                menu.AddItem(new GUIContent(type.Name), false, () =>
                {
                    property.managedReferenceValue = Activator.CreateInstance(type);
                    property.serializedObject.ApplyModifiedProperties();
                });
            }

            menu.ShowAsContext();
        }
    }

    private Type[] GetSubTypes(Type baseType)
    {
        if (!_subTypeCache.TryGetValue(baseType, out Type[] subTypes))
        {
            subTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => baseType.IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
                .ToArray();

            _subTypeCache[baseType] = subTypes;
        }

        return subTypes;
    }

    private Type GetFieldType(SerializedProperty property)
    {
        // 处理数组/List类型
        if (property.type == "managedReference<Array>")
        {
            string arrayTypeName = property.managedReferenceFieldTypename;
            string elementTypeName = arrayTypeName.Substring(0, arrayTypeName.IndexOf('['));
            return Type.GetType(elementTypeName);
        }

        return Type.GetType(property.managedReferenceFieldTypename);
    }
}