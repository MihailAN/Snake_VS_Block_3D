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

    public TextMeshPro SnakeTailText;    
    public Transform Tail;
    public float CircleDiameter;

    private Player _player;
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
        _player= Player.GetComponent<Player>();
        AddTail();
        AddTail();
        AddTail();
        AddTail();
    }

    private void Update()
    {
        float distance = ((Vector3)_snakeHead.position - positions[0]).magnitude;

        if (distance > CircleDiameter)
        {
            Vector3 direction = ((Vector3)_snakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }

        for (int i = 0; i < snakeTail.Count; i++)
        {
            snakeTail[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);
        }
    }

    public void AddTail()
    {
        Transform circle = Instantiate(Tail, positions[positions.Count - 1], 
                                        Quaternion.identity, _snakeHead.transform);
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
    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
