using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Game : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject PanelLost;
    [SerializeField]
    private AnimatorControl animatorControlHead;
    [SerializeField]
    private TextMeshPro SnakeTailText;
    [SerializeField]
    private Transform Tail; 
    [SerializeField]
    private float distanceTail;
    [Min(0)]
    public float Volume;


    private Transform _snakeHead;
    private List<Transform> snakeTail = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    private void Awake()
    {
        _snakeHead = Player.GetComponent<Transform>();
        positions.Add(_snakeHead.position);
              
    }
    private void Start()
    {
        AddTail();
        AddTail();
        AddTail();
        AddTail();
    }
    private void Update()
    {
        AudioListener.volume = Volume;
        float distance = (_snakeHead.position - positions[0]).magnitude;
        if (distance > distanceTail)
        {
            Vector3 direction = (_snakeHead.position - positions[0]).normalized;
            positions.Insert(0, positions[0] + direction * distanceTail);
            positions.RemoveAt(positions.Count - 1);
            distance -= distanceTail;
        }
        for (int i = 0; i < snakeTail.Count; i++)
        {
            snakeTail[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / distanceTail);
        }
    }
    public void AddTail()
    {
        Transform circle = Instantiate(Tail, positions[positions.Count - 1], Quaternion.identity, _snakeHead.transform);
        snakeTail.Add(circle);
        positions.Add(circle.position);        
        TailText();
    }
    public void RemoveTail()
    {        
            if (snakeTail.Count > 0)
            {
                Destroy(snakeTail[0].gameObject);
                snakeTail.RemoveAt(0);
                positions.RemoveAt(1);
                TailText();
            }
            else
            {
                OnPlayerDied();                
            }
    }
    public void TailText()
    { 
        int Tail= snakeTail.Count;
        SnakeTailText.text= Tail.ToString();
    }
    public void OnPlayerDied()
    {        
        animatorControlHead.lostPlaer();
        Player.GetComponent<Player>().enabled = false;
        PanelLost.SetActive(true);
    } 
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ResetLevel()
    {       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToLevel_1()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
