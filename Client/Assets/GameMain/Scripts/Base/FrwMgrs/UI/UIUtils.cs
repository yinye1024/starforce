/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
// UI 相关的工具类，添加UI事件等
//----------------------------------------------------------------*/

using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace GameMain.Base
{
    public static class UIUtils
    {
        public static IEnumerator FadeToAlpha(CanvasGroup canvasGroup, float alpha, float duration)
        {
            float time = 0f;
            float originalAlpha = canvasGroup.alpha;
            while (time < duration)
            {
                time += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(originalAlpha, alpha, time / duration);
                yield return new WaitForEndOfFrame();
            }

            canvasGroup.alpha = alpha;
        }

        public static IEnumerator SmoothValue(Slider slider, float value, float duration)
        {
            float time = 0f;
            float originalValue = slider.value;
            while (time < duration)
            {
                time += Time.deltaTime;
                slider.value = Mathf.Lerp(originalValue, value, time / duration);
                yield return new WaitForEndOfFrame();
            }

            slider.value = value;
        }
        
        public static HashMap<string, GameObject> LoadAllObj(GameObject root)
        {
            HashMap<string, GameObject> goMap = new HashMap<string, GameObject>();
            LoadAllObj(root, "", goMap);
            return goMap;
        }
        private static void LoadAllObj(GameObject root, string path,HashMap<string, GameObject> goMap) {
            foreach (Transform tf in root.transform) {
                if (goMap.HasKey(path + tf.gameObject.name)) {
                    // Debugger.LogWarning("Warning object is exist:" + path + tf.gameObject.name + "!");
                    continue;
                }

                var goTmp = tf.gameObject;
                goMap.Put(path + goTmp.name, goTmp);
                LoadAllObj(tf.gameObject, path + goTmp.name + "/",goMap);
            }

        }
        
        public static void AddBtnClickFun(GameObject btnGo, UnityAction onClickFun) {
            Button btn = btnGo.GetComponent<Button>();
            if (btn == null) {
                Log.Error("UI_manager add_button_listener: not Button Component!");
                return;
            }

            btn.onClick.AddListener(onClickFun);
        }

        public static void AddSliderFun(GameObject sliderGo, UnityAction<float> onValueChangedFun)
        {
            Slider slider = sliderGo.GetComponent<Slider>();
            if (slider == null) {
                Log.Error("UI_manager add_slider_listener: not Slider Component!");
                return;
            }

            slider.onValueChanged.AddListener(onValueChangedFun);
        }
    }
}