using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class QuizControl : MonoBehaviour {
    private List<string[]> questionDatabase = new List<string[]>();
    [SerializeField] private GameObject[] textObjects = new GameObject[5];
    [SerializeField] private int correctIndex;
    void Start() {
        ReadFile();
        NewQuestion();
    }

    void ReadFile() {
        string filePath = "";
        string[] allLines = File.ReadAllLines(filePath);
        for (int i = 0; i < allLines.Length; i++) {
            questionDatabase.Add(allLines[i].Split(','));
        }
    }

    void NewQuestion() {
        int questionIndex = Random.Range(0, questionDatabase.Count);
        textObjects[0].GetComponentInChildren<TMP_Text>().text = questionDatabase[questionIndex][0];
        
        int[] answerOrder = {-1, -1, -1, -1};
        correctIndex = Random.Range(0, 4);
        answerOrder[correctIndex] = 2;
        int randomIndex = correctIndex;
        for (int i = 1; i < 5; i++) {
            if (i != 2) {
                while (answerOrder[randomIndex] != -1) {
                    randomIndex = Random.Range(0, 4);
                }
                answerOrder[randomIndex] = i;
            }
        }
        for (int i = 1; i < 5; i++) {
            textObjects[i].GetComponentInChildren<TMP_Text>().text = questionDatabase[questionIndex][answerOrder[i - 1]];
        }
    }
}
