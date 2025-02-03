using TMPro;
using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    private float nextJudgmentTime; 
    private bool isJudgmentActive;  
    private float judgmentDuration = 0.3f; 
    private float preJudgmentShowTime = 1f; 
    private bool notnow;

    public GameObject judgmentIndicator; 
    public GameObject righttime;
    public GameObject extrahint;
    public GameObject nor;
    public GameObject fail;
    public GameObject fight;

    public userinterface UIscript;

    public float switchDuration = 0.25f;

    private bool isSpecialModeActive; 
    public float specialModeProgress; 
    private float specialModeTimer; 

    public int sp = 15;
    public int score = 5;
    public int healthko = 1;
    public int yuanhealth = 5;
    public int ghosthealth = 5;

    public TMP_Text pwshow;

    public RectTransform mRt;
    public RectTransform mRtphp;
    public RectTransform ghhp;

    public AudioSource daosource;
    public AudioClip daoSound;
    public AudioSource hurtsource;
    public AudioClip hurtSound;

    public float forceAmount = 15f; 

    public GameObject ghost;

    public float duration = 0.5f;  
    public float magnitude = 0.2f; 
    private Vector3 originalLocalPosition;

    public ParticleSystem particleSystem;


    void Start()
    {
        
      
        SetNextJudgmentTime();

        notnow = true;

        // hide
        if (judgmentIndicator != null)
        {
            judgmentIndicator.SetActive(false);
        }

        if (righttime != null)
        {
            righttime.SetActive(false);
            extrahint.SetActive(false);
        }


        if (fail != null)
        {
            fail.SetActive(false);
        }


        fight.SetActive(false);
        nor.SetActive(true);

        particleSystem.Stop();
        UIscript = GameObject.FindFirstObjectByType<userinterface>();
    }

    void Update()
    {
        pwshow.text = specialModeProgress.ToString();
        //check show
        if (Time.time >= nextJudgmentTime - preJudgmentShowTime && !isJudgmentActive)
        {
            ShowJudgmentIndicator();
        }

        //check judgetime
        if (Time.time >= nextJudgmentTime && !isJudgmentActive)
        {
            if (notnow)
            {
                StartJudgment();
            }
            
        }

        //checkpress
        if (isJudgmentActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PassJudgment();
            }

            //fail
            if (Time.time >= nextJudgmentTime + judgmentDuration)
            {
                FailJudgment();
            }
        }

        if (isSpecialModeActive)
        {
            HandleSpecialMode();
            notnow = false;
            
        }
        else
        {
            notnow = true;
        }

        SetHp(70f);

        SetlayerHp(500f);

        SetghostHp(500f);
    }

    //nextrandomtime
    void SetNextJudgmentTime()
    {
        float randomInterval = Random.Range(0.25f, 3f); 
        nextJudgmentTime = Time.time + randomInterval;
    }

    //showindicator
    void ShowJudgmentIndicator()
    {
        if (judgmentIndicator != null)
        {
            judgmentIndicator.SetActive(true);
            nor.SetActive(false);
            ghost.transform.position = new Vector3(5, 2, 0);
        }
    }

    //startjudge
    void StartJudgment()
    {
        isJudgmentActive = true;
        Debug.Log("Judgment Started! Press SPACE to pass!");

        if (righttime != null)
        {
            righttime.SetActive(true);
            extrahint.SetActive(true);
        }
    }


    // pass
    void PassJudgment()
    {
        isJudgmentActive = false;
        Debug.Log("Judgment Passed!");
        HideJudgmentIndicator();
        daosource.clip = daoSound;
        daosource.Play();
        if (righttime != null)
        {
            righttime.SetActive(false);
            extrahint.SetActive(false);

        }
        SetNextJudgmentTime(); 
        ApplyForce();
        StartShake();



        if (Random.Range(0, 6) == 0) //1/6
        {
            isSpecialModeActive = true;
            fight.SetActive(true);
            specialModeProgress = 15f; //startpross
            specialModeTimer = 0f;
            Debug.Log("Special Mode Started! Progress: " + specialModeProgress);
            particleSystem.Play();
        }
        else
        {
            HideJudgmentIndicator();
            SetNextJudgmentTime(); 
            UIscript.AddScore(score);
        }
    }

    //fail
    void FailJudgment()
    {
        isJudgmentActive = false;
        Debug.Log("Judgment Failed!");
        HideJudgmentIndicator();
        if (righttime != null)
        {
            righttime.SetActive(false);
            extrahint.SetActive(false);
        }
        SetNextJudgmentTime(); 
        UIscript.Killhelath(healthko);
        yuanhealth = yuanhealth - 1;
        hurtsource.clip = hurtSound;
        hurtsource.Play();

        StartCoroutine(failchange());

    }

    //hide
    void HideJudgmentIndicator()
    {
        if (judgmentIndicator != null)
        {
            nor.SetActive(true);
            judgmentIndicator.SetActive(false);
        }
    }

    void HandleSpecialMode()
    {
        //autofall
        specialModeTimer += Time.deltaTime;
        if (specialModeTimer >= 1f)
        {
            specialModeProgress -= 5f;
            specialModeTimer = 0f;
            Debug.Log("Special Mode Progress: " + specialModeProgress);
        }

        //spacecheck
        if (Input.GetKeyDown(KeyCode.Space))
        {
            specialModeProgress += 1f;
            Debug.Log("Special Mode Progress: " + specialModeProgress);
        }

        //pass2
        if (specialModeProgress >= 30f)
        {
            EndSpecialMode(true); //sp pass
            UIscript.AddScore(score);
            ghosthealth = ghosthealth - 1;
            UIscript.eyk(healthko);
            UIscript.Plushelath(healthko);
            yuanhealth = yuanhealth + 1;
        }

        //0 fail
        if (specialModeProgress <= 0f)
        {
            EndSpecialMode(false); //sp fail
            UIscript.Killhelath(healthko);
            StartCoroutine(failchange());
            hurtsource.clip = hurtSound;
            hurtsource.Play();
            yuanhealth = yuanhealth - 1;

        }
    }

    //edn sp
    void EndSpecialMode(bool isSuccess)
    {
        isSpecialModeActive = false;
        if (isSuccess)
        {
            Debug.Log("Special Mode Succeeded!");
        }
        else
        {
            Debug.Log("Special Mode Failed!");
        }

        HideJudgmentIndicator();
        SetNextJudgmentTime();
        notnow = true;
        fight.SetActive(false);
        particleSystem.Stop();
    }

    void SetHp(float val)
    {
        

        
        Vector2 cur = mRt.sizeDelta;
        
        cur.x = val * specialModeProgress;
        
        mRt.sizeDelta = cur;
    }

    void SetlayerHp(float val)
    {


      
        Vector2 cur = mRtphp.sizeDelta;
      
        cur.x = val * yuanhealth;
       
        mRtphp.sizeDelta = cur;
    }

    void SetghostHp(float val)
    {


      
        Vector2 cur = ghhp.sizeDelta;
       
        cur.x = val * ghosthealth;
       
        ghhp.sizeDelta = cur;
    }

    System.Collections.IEnumerator failchange() 
    {
        fail.SetActive(true);
        yield return new WaitForSeconds(switchDuration);
        fail.SetActive(false);
    }

    void ApplyForce()
    {
        
        
            Rigidbody2D rb = ghost.GetComponent<Rigidbody2D>();
            
            
            rb.AddForce(Vector2.right * forceAmount, ForceMode2D.Impulse); //right move
            
        
    }

    public void StartShake()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        originalLocalPosition = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = originalLocalPosition + new Vector3(x, y, 0);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalLocalPosition; //back
    }

}

