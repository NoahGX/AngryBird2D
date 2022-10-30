using UnityEngine;
using UnityEngine.SceneManagement;

public class AngryBird : MonoBehaviour
{
    Vector3 _initialPositon;
    private bool _birdWasLaunched;
    private float _timeSittingAround;
    [SerializeField] private float _launchPower = 300;

    private void Awake()
    {
        _initialPositon = transform.position;
    }

    private void Update()
    {
        if (_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }

        if (transform.position.y > 40 ||
            transform.position.y < -40 ||
            transform.position.x > 40 ||
            transform.position.x < -40 ||
            _timeSittingAround > 3)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPosition = _initialPositon - transform.position;

        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunched = true;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
