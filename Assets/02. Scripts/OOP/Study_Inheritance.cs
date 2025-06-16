using System.Collections.Generic;
using UnityEngine;

// Student과 Soldier을 상속을 사용하여 함수를 호출하는 스크립트
public class Study_Inheritance : MonoBehaviour
{
    // Person 상속 쓰기전 Student Soldier을 담을 리스트 생성
    // public List<Student> students = new List<Student>();
    // public List<Soldier> soldiers = new List<Soldier>();
    
    // Person을 담을 리스트 생성 
    public List<Person> persons = new List<Person>();
    void Start()
    {
        // Person 상속 쓰기전 
        // for (int i = 0; i < 10; i++) // Student 10명 생성
        // {
        //     Student student = new Student();
        //     students.Add(student);
        // }
        // for (int i = 0; i < 10; i++) // Soldier 10명 생성
        // {
        //     Soldier soldier = new Soldier();
        //     soldiers.Add(soldier);
        // }

        for (int i = 0; i < 10; i++)
        {
            Student student = new Student();
            persons.Add(student);
            Soldier soldier = new Soldier();
            persons.Add(soldier);
        }
    }

    public void AllMove() // 모든 객체마다 이동 기능 실행
    {
        // Person 상속 쓰기전 
        // foreach (Student stu in students)
        //     stu.Walk();
        //
        // foreach (Soldier sol in soldiers)
        //     sol.Walk();

        foreach (var person  in persons)
        {
            person.Walk();
        }
    }
}
