using core;
using UnityEngine;

public class EnemyManager:MonoBehaviour
{
    private StateMachine<BossStateData> bossSM;
    private SlimeRefs slimeRefs;
    [SerializeField] private Transform PlayerTf;
    [SerializeField] private GameObject SlimePrefab;
    [SerializeField] private OnRoom onRoom;

    public void Start()
    {
        slimeRefs = new();
        bossSM = CreateBossSM();
       bossSM.Enter();
    }
    public void Update()
    {
        bossSM.Tick();
    }
    public void OnDisable()
    {
        bossSM.Exit();
    }

    private StateMachine<BossStateData> CreateBossSM()
    {
        SlimeState slime = new(CreateSlimeSM(),SlimePrefab,slimeRefs);
        CloudState cloud = new CloudState();
        BossStateData data = new(slime,cloud);
        return new StateMachine<BossStateData>(data);
    }

    private StateMachine<SlimeStateData>CreateSlimeSM()
    {
        SlimeStateData data = new(
            new IdleState(slimeRefs,onRoom),
            new RushState(slimeRefs,PlayerTf),
            new JumpState(slimeRefs,PlayerTf),
            new ReturnState(slimeRefs));
        return new StateMachine<SlimeStateData>(data);
    }
}
