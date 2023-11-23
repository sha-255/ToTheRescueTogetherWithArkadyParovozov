using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test : MonoBehaviour
{
    [SerializeField] private TestQuestion testPrefab;
    [SerializeField] private RectTransform invokateTest;
    [SerializeField] private UnityEvent Win;
    //[SerializeField] private ParticleSystem ParticleSystem;
    private Question[] questions;
    List<TestQuestion> testQuestions = new();
    private int curQuestion = 0;

    public void Spawn()
    {
        questions = Resources.LoadAll<Question>("Questions");
        foreach (var question in questions)
        {
            print(question);
            var pref = Instantiate(testPrefab, invokateTest);
            pref.Question = question;
            pref.RightClicked.AddListener(() => MoveNextQuestion());//
            pref.gameObject.SetActive(false);
            print(pref);
            testQuestions.Add(pref);//
        }
        testQuestions[curQuestion].gameObject.SetActive(true);
    }

    private void MoveNextQuestion()
    {
        if (curQuestion + 1 >= testQuestions.Count)
        {
            Win?.Invoke();
            testQuestions[curQuestion].gameObject.SetActive(false);
            print("Win!");
            return;
        }
        //var partSys = Instantiate(ParticleSystem);
        //Destroy(partSys, 1f);
        testQuestions[curQuestion].gameObject.SetActive(false);
        curQuestion++;
        testQuestions[curQuestion].gameObject.SetActive(true);
    }
}
