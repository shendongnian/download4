    public float Interval = 1;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        // DO THIS ONLY ONCE
        if(!spriteRenderer) spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable ()
    {
        // Start invoking every Interval seconds
        InvokeRepeating(nameOf(ChangeColor), Interval, Interval);
    }
    private void OnDisable()
    {
        // Stop the repeated invoking 
        CancelInvoke();
    }
    private void ChangeColor()
    {
        Debug.Log("Hello");
        color = Random.Range(1, 5);
        // You should also use a switch case here
        switch(color)
        {
            case 2:
                spriteRenderer.color = Color.blue;
                break;
        
            case 3:
                spriteRenderer.color = Color.red;
                break;
        
            case 4:
                 spriteRenderer.color = Color.yellow;
                 break;
        }
    }
