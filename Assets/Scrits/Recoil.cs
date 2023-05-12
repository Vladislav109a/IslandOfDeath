using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    [SerializeField] private Transform recoilPosition;
    [SerializeField] private Transform recoilPoint;

    [SerializeField] private float positionRecoilSpeed = 8f;
    [SerializeField] private float rotationRecoilSpeed = 8f;
    
    [SerializeField] private float positionReturnSpeed = 18f;
    [SerializeField] private float rotationReturnSpeed = 38f;

    [SerializeField] private Vector3 RecoilRotation = new Vector3(10, 5, 7);
    [SerializeField] private Vector3 RecoilKickBack = new Vector3(0.015f, 0f, -0.2f);

    [SerializeField]
    private Vector3 RecoilRotationAim = new Vector3(10, 4, 6);
    [SerializeField]private Vector3 RecoilKickBackAim = new Vector3(0.015f, 0f, -0.2f);

    Vector3 rotationalRecoil;
    Vector3 positionalRecoil;
    Vector3 Rot;
    public bool aiming;

    private void FixedUpdate()
    {
        rotationalRecoil = Vector3.Lerp(rotationalRecoil, Vector3.zero, rotationReturnSpeed * Time.deltaTime);
        positionalRecoil = Vector3.Lerp(positionalRecoil, Vector3.zero, positionReturnSpeed * Time.deltaTime);

        recoilPosition.localPosition = Vector3.Slerp(recoilPosition.localPosition, positionalRecoil, positionRecoilSpeed * Time.fixedDeltaTime);
        Rot = Vector3.Slerp(Rot, rotationalRecoil, rotationRecoilSpeed * Time.fixedDeltaTime);
        recoilPoint.localRotation = Quaternion.Euler(Rot);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
        if (Input.GetButton("Fire2"))
        {
            aiming = true;
        }
        else
        {
            aiming = false;
        }
    }
    public void Fire()
    {
        if (aiming)
        {
            rotationalRecoil += new Vector3(-RecoilRotationAim.x, Random.Range(-RecoilRotationAim.y, RecoilRotationAim.y), Random.Range(-RecoilRotationAim.z, RecoilRotationAim.z));
            positionalRecoil += new Vector3(Random.Range(-RecoilKickBackAim.x,RecoilKickBackAim.x), Random.Range(-RecoilKickBackAim.y, RecoilKickBackAim.y), Random.Range(-RecoilKickBackAim.z, RecoilKickBackAim.z));
        }
        else
        {
            rotationalRecoil += new Vector3(-RecoilRotation.x, Random.Range(-RecoilRotation.y, RecoilRotation.y), Random.Range(-RecoilRotation.z, RecoilRotation.z));
            positionalRecoil += new Vector3(Random.Range(-RecoilKickBack.x, RecoilKickBack.x), Random.Range(-RecoilKickBack.y, RecoilKickBack.y), Random.Range(-RecoilKickBack.z, RecoilKickBack.z));
        }
    }
}
