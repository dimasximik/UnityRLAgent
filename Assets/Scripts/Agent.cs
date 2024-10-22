using System.Collections;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] private float moveStep = 1f;
    [SerializeField] private float rotationStep = 30f;
    [SerializeField] private float learningRate = 0.1f;
    [SerializeField] private float discountFactor = 0.9f;
    [SerializeField] private float explorationRate = 1.0f;
    [SerializeField] private float explorationDecay = 0.995f;
    [SerializeField] private float minExplorationRate = 0.01f;
    [SerializeField] private int maxStepsPerEpisode = 200;
    [SerializeField] private float stepDelay = 0f;

    private QLearning _qLearning;
    private Vector3 _initialPosition;
    private Quaternion _initialRotation;
    private Target _target;
    private int _stepCount;
    private float _previousDistance;

    void Start()
    {
        _qLearning = new QLearning();

        _initialPosition = transform.position;
        _initialRotation = transform.rotation;

        _target = FindObjectOfType<Target>();

        _stepCount = 0;

        _previousDistance = Vector3.Distance(transform.position, _target.transform.position);

        StartCoroutine(LearningCoroutine());
    }

    IEnumerator LearningCoroutine()
    {
        while (true)
        {
            if (_stepCount >= maxStepsPerEpisode)
            {
                ResetEnvironment();
                yield return null;
                continue;
            }

            string state = GetState();

            string action = _qLearning.ChooseAction(state, explorationRate);

            ExecuteAction(action);

            float newDistance = Vector3.Distance(transform.position, _target.transform.position);

            float reward;
            if (newDistance < 1.0f)
            {
                reward = 100.0f;
            }
            else
            {
                reward = _previousDistance - newDistance;
                reward -= 0.1f;
            }

            string newState = GetState();

            _qLearning.UpdateQ(state, action, reward, newState, learningRate, discountFactor);

            _previousDistance = newDistance;

            if (newDistance < 1.0f)
            {
                ResetEnvironment();
            }

            explorationRate = Mathf.Max(minExplorationRate, explorationRate * explorationDecay);

            _stepCount++;

            if (stepDelay > 0f)
            {
                yield return new WaitForSeconds(stepDelay);
            }
            else
            {
                yield return null;
            }
        }
    }

    string GetState()
    {
        float dx = _target.transform.position.x - transform.position.x;
        float dz = _target.transform.position.z - transform.position.z;

        string state = "";

        if (dx > 4)
            state += "VeryFarRight_";
        else if (dx > 2)
            state += "FarRight_";
        else if (dx > 0.5f)
            state += "NearRight_";
        else if (dx < -0.5f)
            state += "NearLeft_";
        else if (dx < -2)
            state += "FarLeft_";
        else if (dx < -4)
            state += "VeryFarLeft_";
        else
            state += "Center_";

        if (dz > 4)
            state += "VeryFarForward";
        else if (dz > 2)
            state += "FarForward";
        else if (dz > 0.5f)
            state += "NearForward";
        else if (dz < -0.5f)
            state += "NearBackward";
        else if (dz < -2)
            state += "FarBackward";
        else if (dz < -4)
            state += "VeryFarBackward";
        else
            state += "Center";

        return state;
    }

    void ExecuteAction(string action)
    {
        switch (action)
        {
            case "MoveForward":
                transform.Translate(Vector3.forward * moveStep, Space.World);
                break;
            case "MoveBackward":
                transform.Translate(Vector3.back * moveStep, Space.World);
                break;
            case "MoveLeft":
                transform.Translate(Vector3.left * moveStep, Space.World);
                break;
            case "MoveRight":
                transform.Translate(Vector3.right * moveStep, Space.World);
                break;
            case "RotateLeft":
                transform.Rotate(Vector3.up, -rotationStep);
                break;
            case "RotateRight":
                transform.Rotate(Vector3.up, rotationStep);
                break;
            default:
                break;
        }
    }

    void ResetEnvironment()
    {
        transform.position = _initialPosition;
        transform.rotation = _initialRotation;

        _target.ResetTarget();

        _stepCount = 0;

        _previousDistance = Vector3.Distance(transform.position, _target.transform.position);
    }
}