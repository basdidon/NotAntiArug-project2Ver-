using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public List<Dialogue> dialogues;
    
    public Queue<Dialogue.Speaker> speakers;
    public Queue<string> sentences;

    public bool isTalking = false;

    [Header("UI Component")]
    public GameObject dialogBox;
    public Text NameText;
    public Text dialogText;
    public Image speakerImage;

    [Header("Sprite")]
    public Sprite PlayerSprite, DoctorSprite, Boss1Sprite, Boss2Sprite, Boss3Sprite;

    void Start()
    {
        instance = this;

        sentences = new Queue<string>();
        speakers = new Queue<Dialogue.Speaker>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isTalking = true;
        //Debug.Log("Starting conversation with "+dialogue.speaker.ToString());
        dialogBox.SetActive(true);
        //Player.instance.gameObject.SetActive(false);
        Time.timeScale = 0;

        //NameText.text = dialogue.speaker.ToString();

        foreach(Dialogue.Speaker speaker in dialogue.speaker)
        {
            speakers.Enqueue(speaker);
        }

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
    }

    public void DisplayNextSentence()
    {
        Debug.Log("DisplayNextSentence : " + sentences.Count + "," + speakers.Count);
        if (sentences.Count == 0 || speakers.Count == 0)
        {
            EndDialogue();
        }
        //set name on UI
        NameText.text = Dialogue.inGameNameSpeaker[speakers.Peek().GetHashCode()];
        
        switch (speakers.Dequeue())
        {
            case Dialogue.Speaker.player:
                speakerImage.sprite = PlayerSprite;
                break;
            case Dialogue.Speaker.doctor:
                speakerImage.sprite = DoctorSprite;
                break;
            case Dialogue.Speaker.Boss1:
                speakerImage.sprite = Boss1Sprite;
                break;
            case Dialogue.Speaker.Boss2:
                speakerImage.sprite = Boss2Sprite;
                break;
            case Dialogue.Speaker.Boss3:
                speakerImage.sprite = Boss3Sprite;
                break;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
        Debug.Log(sentence);
    }

    public void EndDialogue()
    {
        isTalking = false;
        Debug.Log("End of conversation");
        dialogBox.SetActive(false);
        Player.instance.gameObject.SetActive(true);
        Time.timeScale = 1;
    }
}
