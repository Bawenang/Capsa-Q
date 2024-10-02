using UnityEngine;

public class MainEventHandler
{
    public delegate void OnStart();
    public event OnStart onStart;

    public delegate void OnCalculateLogic();
    public event OnCalculateLogic onCalculateLogic;

    public void StartInit()
    {
        if(onStart != null) onStart();
    }

    public void DoCalculations()
    {
        if(onCalculateLogic != null) onCalculateLogic();
    }
}

public class MainLogic
{
    public void DoInitialization()
    {
        Debug.Log("Init!");
    }
    public void DoLogic()
    {
        Debug.Log("Logical block!");
    }
}

public interface IStateTest
{
    void Setup(object properties);
    void CleanUp();
}

public class StateA: IStateTest
{
    public class Properties
    {
         public MainEventHandler eventHandler;
         public MainLogic logic;
    }

    private Properties props;

    public void Setup(object properties)
    {
        props = properties as Properties;
        props.eventHandler.onStart += Start;
    }

    public void CleanUp()
    {
        props.eventHandler.onStart -= Start;
    }

    private void Start() //Doesn't get triggered because onStart is null
    {
        Debug.Log("Start called!");
        props.logic.DoInitialization();
    }
}

public class StateB: IStateTest
{
    public class Properties
    {
         public MainEventHandler eventHandler;
         public MainLogic logic;
    }

    private Properties props;

    public void Setup(object properties)
    {
        props = properties as Properties;
        props.eventHandler.onCalculateLogic += Calculate;
    }

    public void CleanUp()
    {
        props.eventHandler.onCalculateLogic -= Calculate;
    }

    private void Calculate() //Doesn't get triggered because onCalculateLogic is null
    {
        Debug.Log("Calculate called!");
        props.logic.DoLogic();
    }
}

public class StateControl
{
    public MainEventHandler EventHandler { get => eventHandler; }

    private IStateTest currentState;
    private MainEventHandler eventHandler = new MainEventHandler();
    private MainLogic logic = new MainLogic();

    public void ActivateState(IStateTest toActivate)
    {
        if (toActivate is StateA) 
        {
            var properties = new StateA.Properties();
            properties.eventHandler = eventHandler;
            properties.logic = logic;
            toActivate.Setup(properties);
        }
        else if (toActivate is StateB) 
        {
            var properties = new StateB.Properties();
            properties.eventHandler = eventHandler;
            properties.logic = logic;
            toActivate.Setup(properties);
        }
    }

    public void Start()
    {
        eventHandler.StartInit();
    }

    public void DoLogic()
    {
        eventHandler.DoCalculations();
    }
}

public class MainSceneController: MonoBehaviour
{
    private StateControl stateController = new StateControl();
    private StateA firstState = new StateA();
    private StateB secondState = new StateB();
    void Awake()
    {
        stateController.ActivateState(firstState);
    }

    void Start()
    {
        stateController.Start();
        stateController.ActivateState(secondState);
    }

    void Update()
    {
        stateController.DoLogic();
    }
}