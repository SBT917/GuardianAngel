using UnityEngine;

public class BallController : MonoBehaviour
{
    public float forceAmount = 10f; // ������ԗ͂̑傫��

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("�Փ�");
        if (collision.gameObject.CompareTag("Player")) // �v���C���[�ɐG�ꂽ��
        {
            Debug.Log("�v���C���[��");
            Vector3 direction = (transform.position - collision.transform.position).normalized; // �G�ꂽ�������v�Z
            Rigidbody rb = GetComponent<Rigidbody>(); // �{�[����Rigidbody���擾

            if (rb != null)
            {
                rb.AddForce(direction * forceAmount, ForceMode.Impulse); // ���Ε����ɗ͂�������
            }
        }
    }
}
