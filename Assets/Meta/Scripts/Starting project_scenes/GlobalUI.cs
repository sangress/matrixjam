﻿using System.Collections;
using System.Collections.Generic;
using Basic_Matrix;
using UnityEngine;
using UnityEngine.UI;

namespace Basic_Matrix
{
    [UnitySingleton(UnitySingletonAttribute.Type.ExistsInScene, false)]
    public class GlobalUI : UnitySingleton<GlobalUI>
    {

        private const int TOTAL_SKIPS = 7;
        private int _currentSkipsAmount = 0;
        
        [Header("UI")] 
        public GameObject Container;
        public Text SkipsLeftText;
        public Text GamesDoneText;
        public Button ResumeButton;
        public Button SkipButton;
        public Button RestartButton;
        public Button ExitButton;

        // Start is called before the first frame update
        void Start()
        {
            // initialize buttons
            ExitButton.onClick.AddListener(() =>
            {
                SceneManager.SceneMang.LoadScene("Start");
            });

            RestartButton.onClick.AddListener(() =>
            {
                SceneManager.SceneMang.ResetLevelScene();
            });
            
            SkipButton.onClick.AddListener(() =>
            {
               SkipLevel();
            });
            
            ResumeButton.onClick.AddListener(() =>
            {
                ToggleUI();
            });
            
            // initialize text feilds
            UpdateSkipsFields(_currentSkipsAmount.ToString(), TOTAL_SKIPS.ToString());
            // TODO: link total number of levels
            UpdateGamesDoneFields("0", "7");
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ToggleUI();
            }
        }

        public void ToggleUI()
        {
            // enable object
            Container.SetActive(!Container.activeSelf);
            
            // TODO: pause game
            //Time.timeScale = Container.activeSelf ? 0 : 1;
            //LevelHolder.Pause(Container.activeSelf)
        }

        public void UpdateSkipsFields(string skipsLeft, string skipsTotal)
        {
            SkipsLeftText.text = $"{skipsLeft}/{skipsTotal}";
        }
        
        public void UpdateGamesDoneFields(string gamesDone, string gamesDoneTotal)
        {
            GamesDoneText.text = $"{gamesDone}/{gamesDoneTotal}";
        }

        public void SkipLevel()
        {
            if (_currentSkipsAmount >= TOTAL_SKIPS)
                return;
            
            // TODO: get the next level scene name
            // SceneManager.SceneMang.LoadScene(scene level name);
            
            _currentSkipsAmount++;

            UpdateSkipsFields(_currentSkipsAmount.ToString(), TOTAL_SKIPS.ToString());
        }
    }
}