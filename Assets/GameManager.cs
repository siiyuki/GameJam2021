using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float ���x���A�b�v�̃C���^�[�o��;
    public float ���ꂪ������܂ł̎���;
    public float �^�C�}�[�J�n����;
    public float �X�|�i�[����;
    public float �X�|�i�[���߂̃C���^�[�o��;
    public float �X�|�i�[���߂̍R��;
    public float �X�|�i�[�폜�̏c��;
    public float �X�|�i�[�I�u�W�F�N�g�̏d��;
    public float �X�|�i�[��]����;
    public float �X�|�i�[�J�n����;
    public bool �X�|�i�[�X�|�[������]X; 
    public bool �X�|�i�[�X�|�[������]Y; 
    public bool �X�|�i�[�X�|�[������]Z;
    public float ���x���[�ڕW���x���l;
    public float ���x���[�ڕW�R�͒l;
    public KeyCode ����L�[��, ����L�[�E, ����L�[��, ����L�[��, ����L�[�W�����v;

    private void Awake()
    {
        GameObject.Find("StartBase").GetComponent<StartBase>().brakeTime = ���ꂪ������܂ł̎���;
        var tc = GameObject.Find("TimeCanvas").GetComponent<CountUP>();
        tc.Cycle = ���x���A�b�v�̃C���^�[�o��;
        tc.StartTime = �^�C�}�[�J�n����;
        var os = GameObject.Find("ObjectSpawner").GetComponent<ObjectSpawner>();
        os.MaxWidth = �X�|�i�[����;
        os.SpawnInterval = �X�|�i�[���߂̃C���^�[�o��;
        os.DestroyHeight = �X�|�i�[�폜�̏c��;
        os.ObjectMass = �X�|�i�[�I�u�W�F�N�g�̏d��;
        os.ObjectDrag = �X�|�i�[���߂̍R��;
        os.ObjectAngularDrag = �X�|�i�[��]����;
        os.StartTime = �X�|�i�[�J�n����;
        os.RotateX = �X�|�i�[�X�|�[������]X;
        os.RotateY = �X�|�i�[�X�|�[������]Y;
        os.RotateZ = �X�|�i�[�X�|�[������]Z;
        var l = GameObject.Find("Leveler").GetComponent<ChangeLevel>();
        l.SpawnIntervalLevelRate = ���x���[�ڕW���x���l;
        l.ObjectDragLevelRate = ���x���[�ڕW�R�͒l;
    }
}
