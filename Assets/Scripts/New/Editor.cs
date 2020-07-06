//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine.UI;
//using UnityEngine;

//[CustomEditor(typeof(SkillScriptable))]
//public class MyScriptEditor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        //DrawDefaultInspector();

//        SkillScriptable skill = target as SkillScriptable;

//        if (skill.skillEffects.Count == 0) return;

//        var effectType = skill.skillEffects[0].skillEffectType;

//        var effectenum = (SkillEffectType)EditorGUILayout.EnumPopup("ChangeHealth", effectType);

//        SerializedObject serializedObject = new UnityEditor.SerializedObject(skill);
//        ChangeHealth effect = new ChangeHealth();
//        effect.value = EditorGUILayout.FloatField(effect.value, "tete");
//        skill.skillEffects[0] = effect;


//        SerializedProperty serializedPropertyMyClass = serializedObject.FindProperty("changeHealth");
//        serializedPropertyMyClass.NextVisible(true);

//        EditorGUILayout.PropertyField(serializedPropertyMyClass, true);



//        EditorGUILayout.LabelField("Custom editor:");
//            //var serializedObject = new SerializedObject(skill);
//            //var property = serializedObject.FindProperty("changeHealth");
//            //serializedObject.Update();
//            //EditorGUILayout.PropertyField(property, true);
//            //serializedObject.ApplyModifiedProperties();


        
        
//        switch (effectType)
//        {
//            case SkillEffectType.ChangeHealth:
//                skill.skillEffects[0] = new ChangeHealth();
//                skill.text = EditorGUILayout.TextField("changeHealth", skill.text);
//                break;
//            default:
//                break;
//        }


//        //if (skillEffect.flag)
//            //skillEffect.i = EditorGUILayout.IntSlider("I field:", skillEffect.i, 1, 100);

//    }
//}
