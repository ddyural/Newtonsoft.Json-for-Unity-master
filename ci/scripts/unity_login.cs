using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject AdminScreen;
    public GameObject TutorScreen;
    public GameObject StudentScreen;
    public GameObject AddUserScreen;
    public GameObject AddTaskScreen;
    public GameObject TheoryScreen;
    public GameObject TestScreen;
    public GameObject ControlScreen;
    public GameObject ResultScreen;

    public GameObject inputField1;
    public GameObject inputField2;

    public TextMeshProUGUI user_name;
    public TMP_InputField login_inputField;
    public TMP_InputField password_inputField;

    Dictionary<string, string> dictAdmins = new Dictionary<string, string>();

    Dictionary<string, string> dictTutors = new Dictionary<string, string>();

    Dictionary<string, string> dictStudents = new Dictionary<string, string>();

    private string input;




    //public string Login = "";

    //public string Password = "";


    // Start is called before the first frame update
    void Start()
    {
        dictAdmins.Add("Admin", "Admin");
        dictTutors.Add("T", "T");
        dictStudents.Add("S", "S");
        HideAllScreens();
        MainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideAllScreens()
    {
        MainMenu.SetActive(false);

        AdminScreen.SetActive(false);
        TutorScreen.SetActive(false);
        StudentScreen.SetActive(false);

        AddUserScreen.SetActive(false);

        AddTaskScreen.SetActive(false);

        TheoryScreen.SetActive(false);
        TestScreen.SetActive(false);
        ControlScreen.SetActive(false);
        ResultScreen.SetActive(false);
    }

    public void OpenScreenAdmin()
    {
        HideAllScreens();
        AdminScreen.SetActive(true);
    }

    public void OpenScreenTutor()
    {
        HideAllScreens();
        TutorScreen.SetActive(true);
    }

    public void OpenScreenStudent()
    {
        HideAllScreens();
        StudentScreen.SetActive(true);
    }

    public void LoginCheck()
    {   
        string Login = login_inputField.text;
        string Password = password_inputField.text;

        Debug.Log(Login);
        Debug.Log(Password);

        bool foundInDict1 = dictAdmins.ContainsKey(Login) && dictAdmins[Login] == Password;
        bool foundInDict2 = dictTutors.ContainsKey(Login) && dictTutors[Login] == Password;
        bool foundInDict3 = dictStudents.ContainsKey(Login) && dictStudents[Login] == Password;

        if (foundInDict1)
        {
            Debug.Log($"Элемент с ключом {Login} и значением {Password} найден в первом словаре");
            OpenScreenAdmin();
        }
        else if (foundInDict2)
        {
            OpenScreenTutor();
            Debug.Log($"Элемент с ключом {Login} и значением {Password} найден во втором словаре");
        }
        else if (foundInDict3)
        {
            OpenScreenStudent();
            Debug.Log($"Элемент с ключом {Login} и значением {Password} найден в третьем словаре");
        }
        else
        {
            Debug.Log($"Элемент с ключом {Login} и значением {Password} не найден ни в одном из словарей");
        }
        

    }

    public void OpenScreenAddUser()
    {
        HideAllScreens();
        AddUserScreen.SetActive(true);
    }

    public void OpenScreenAddTask()
    {
        HideAllScreens();
        AddTaskScreen.SetActive(true);
    }

    public void OpenTheory ()
    {
        HideAllScreens();
        TheoryScreen.SetActive(true);
    }

    public void OpenTest ()
    {
        HideAllScreens();
        TestScreen.SetActive(true);
    }

    public void OpenControl ()
    {
        HideAllScreens();
        ControlScreen.SetActive(true);
    }

    public void OpenResult ()
    {
        HideAllScreens();
        ResultScreen.SetActive(true);
    }



    public void HowWorksLoginProcess()
    {
        
    }
}
