using System;
using UnityEngine;
public static class TransformExtensions
{
    public static Transform Clear(this Transform transform)
    {
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
        return transform;
    }

    public static void SetPositionX(this Transform trans, float x)
	{
		Vector3 position = trans.position;
		position.x = x;
		trans.position = position;
	}
	public static void SetPositionY(this Transform trans, float y)
	{
        Vector3 position = trans.position;
		position.y = y;
		trans.position = position;
	}
	public static void SetPositionZ(this Transform trans, float z)
	{
		Vector3 position = trans.position;
		position.z = z;
		trans.position = position;
	}
	public static void AddPositionX(this Transform trans, float x)
	{
		trans.SetPositionX(trans.transform.position.x + x);
	}
	public static void AddPositionY(this Transform trans, float y)
	{
		trans.SetPositionY(trans.transform.position.y + y);
	}
	public static void AddPositionZ(this Transform trans, float z)
	{
		trans.SetPositionZ(trans.transform.position.z + z);
	}
	public static void SetLocalPositionX(this Transform trans, float x)
	{
		Vector3 localPosition = trans.localPosition;
		localPosition.x = x;
		trans.localPosition = localPosition;
	}
	public static void SetLocalPositionY(this Transform trans, float y)
	{
		Vector3 localPosition = trans.localPosition;
		localPosition.y = y;
		trans.localPosition = localPosition;
	}
	public static void SetLocalPositionZ(this Transform trans, float z)
	{
		Vector3 localPosition = trans.localPosition;
		localPosition.z = z;
		trans.localPosition = localPosition;
	}
	public static void AddLocalPositionX(this Transform trans, float x)
	{
		trans.SetLocalPositionX(trans.transform.localPosition.x + x);
	}
	public static void AddLocalPositionY(this Transform trans, float y)
	{
		trans.SetLocalPositionY(trans.transform.localPosition.y + y);
	}
	public static void AddLocalPositionZ(this Transform trans, float z)
	{
		trans.SetLocalPositionZ(trans.transform.localPosition.z + z);
	}
	public static void SetEulerAnglesX(this Transform trans, float x)
	{
		Vector3 eulerAngles = trans.eulerAngles;
		eulerAngles.x = x;
		trans.eulerAngles = eulerAngles;
	}
	public static void SetEulerAnglesY(this Transform trans, float y)
	{
		Vector3 eulerAngles = trans.eulerAngles;
		eulerAngles.y = y;
		trans.eulerAngles = eulerAngles;
	}
	public static void SetEulerAnglesZ(this Transform trans, float z)
	{
		Vector3 eulerAngles = trans.eulerAngles;
		eulerAngles.z = z;
		trans.eulerAngles = eulerAngles;
	}
	public static void AddEulerAnglesX(this Transform trans, float x)
	{
		trans.SetEulerAnglesX(trans.transform.eulerAngles.x + x);
	}
	public static void AddEulerAnglesY(this Transform trans, float y)
	{
		trans.SetEulerAnglesY(trans.transform.eulerAngles.y + y);
	}
	public static void AddEulerAnglesZ(this Transform trans, float z)
	{
		trans.SetEulerAnglesZ(trans.transform.eulerAngles.z + z);
	}
	public static void SetLocalEulerAnglesX(this Transform trans, float x)
	{
		Vector3 localEulerAngles = trans.localEulerAngles;
		localEulerAngles.x = x;
		trans.localEulerAngles = localEulerAngles;
	}
	public static void SetLocalEulerAnglesY(this Transform trans, float y)
	{
		Vector3 localEulerAngles = trans.localEulerAngles;
		localEulerAngles.y = y;
		trans.localEulerAngles = localEulerAngles;
	}
	public static void SetLocalEulerAnglesZ(this Transform trans, float z)
	{
		Vector3 localEulerAngles = trans.localEulerAngles;
		localEulerAngles.z = z;
		trans.localEulerAngles = localEulerAngles;
	}
	public static void AddLocalEulerAnglesX(this Transform trans, float x)
	{
		trans.SetLocalEulerAnglesX(trans.transform.localEulerAngles.x + x);
	}
	public static void AddLocalEulerAnglesY(this Transform trans, float y)
	{
		trans.SetLocalEulerAnglesY(trans.transform.localEulerAngles.y + y);
	}
	public static void AddLocalEulerAnglesZ(this Transform trans, float z)
	{
		trans.SetLocalEulerAnglesZ(trans.transform.localEulerAngles.z + z);
	}
	public static void SetRotationX(this Transform trans, float x)
	{
		Quaternion rotation = trans.rotation;
		rotation.x = x;
		trans.rotation = rotation;
	}
	public static void SetRotationY(this Transform trans, float y)
	{
		Quaternion rotation = trans.rotation;
		rotation.y = y;
		trans.rotation = rotation;
	}
	public static void SetRotationZ(this Transform trans, float z)
	{
		Quaternion rotation = trans.rotation;
		rotation.z = z;
		trans.rotation = rotation;
	}
	public static void SetRotationW(this Transform trans, float w)
	{
		Quaternion rotation = trans.rotation;
		rotation.w = w;
		trans.rotation = rotation;
	}
	public static void AddRotationX(this Transform trans, float x)
	{
		trans.SetRotationX(trans.rotation.x + x);
	}
	public static void AddRotationY(this Transform trans, float y)
	{
		trans.SetRotationY(trans.rotation.y + y);
	}
	public static void AddRotationZ(this Transform trans, float z)
	{
		trans.SetRotationZ(trans.rotation.z + z);
	}
	public static void AddRotationW(this Transform trans, float w)
	{
		trans.SetRotationW(trans.rotation.w + w);
	}
	public static void SetLocalRotationX(this Transform trans, float x)
	{
		Quaternion localRotation = trans.localRotation;
		localRotation.x = x;
		trans.localRotation = localRotation;
	}
	public static void SetLocalRotationY(this Transform trans, float y)
	{
		Quaternion localRotation = trans.localRotation;
		localRotation.y = y;
		trans.localRotation = localRotation;
	}
	public static void SetLocalRotationZ(this Transform trans, float z)
	{
		Quaternion localRotation = trans.localRotation;
		localRotation.z = z;
		trans.localRotation = localRotation;
	}
	public static void SetLocalRotationW(this Transform trans, float w)
	{
		Quaternion localRotation = trans.localRotation;
		localRotation.w = w;
		trans.localRotation = localRotation;
	}
	public static void AddLocalRotationX(this Transform trans, float x)
	{
		trans.SetLocalRotationX(trans.localRotation.x + x);
	}
	public static void AddLocalRotationY(this Transform trans, float y)
	{
		trans.SetLocalRotationY(trans.localRotation.y + y);
	}
	public static void AddLocalRotationZ(this Transform trans, float z)
	{
		trans.SetLocalRotationZ(trans.localRotation.z + z);
	}
	public static void AddLocalRotationW(this Transform trans, float w)
	{
		trans.SetLocalRotationW(trans.localRotation.w + w);
	}
	public static void SetLocalScaleX(this Transform trans, float x)
	{
		Vector3 localScale = trans.localScale;
		localScale.x = x;
		trans.localScale = localScale;
	}
	public static void SetLocalScaleY(this Transform trans, float y)
	{
		Vector3 localScale = trans.localScale;
		localScale.y = y;
		trans.localScale = localScale;
	}
	public static void SetLocalScaleZ(this Transform trans, float z)
	{
		Vector3 localScale = trans.localScale;
		localScale.z = z;
		trans.localScale = localScale;
	}
	public static void AddLocalScaleX(this Transform trans, float x)
	{
		trans.SetLocalScaleX(trans.localScale.x + x);
	}
	public static void AddLocalScaleY(this Transform trans, float y)
	{
		trans.SetLocalScaleY(trans.localScale.y + y);
	}
	public static void AddLocalScaleZ(this Transform trans, float z)
	{
		trans.SetLocalScaleZ(trans.localScale.z + z);
	}
    public static void SetLeft(this RectTransform trans, float l)
    {
        Vector3 offsetMin = trans.offsetMin;
        offsetMin.x = l;
        trans.offsetMin = offsetMin;
    }
    public static void SetTop(this RectTransform trans, float t)
    {
        Vector3 offsetMax = trans.offsetMax;
        offsetMax.y = -t;
        trans.offsetMax = offsetMax;
    }
    public static void SetRight(this RectTransform trans, float r)
    {
        Vector3 offsetMax = trans.offsetMax;
        offsetMax.x = -r;
        trans.offsetMax = offsetMax;
    }
    public static void SetBottom(this RectTransform trans, float b)
    {
        Vector3 offsetMin = trans.offsetMin;
        offsetMin.y = b;
        trans.offsetMin = offsetMin;
    }
    public static void SetWdith(this RectTransform trans, float w)
    {
        Vector2 size = trans.sizeDelta;
        size.x = w;
        trans.sizeDelta = size;
    }
    public static void SetHeight(this RectTransform trans, float h)
    {
        Vector2 size = trans.sizeDelta;
        size.y = h;
        trans.sizeDelta = size;
    }
    public static void AddWdith(this RectTransform trans, float w)
    {
        Vector2 size = trans.sizeDelta;
        size.x += w;
        trans.sizeDelta = size;
    }
    public static void AddHeight(this RectTransform trans, float h)
    {
        Vector2 size = trans.sizeDelta;
        size.y += h;
        trans.sizeDelta = size;
    }
    public static void SetAnchorPositionX(this RectTransform trans, float x)
    {
        Vector2 pos = trans.anchoredPosition;
        pos.x = x;
        trans.anchoredPosition = pos;
    }
    public static void SetAnchorPositionY(this RectTransform trans, float y)
    {
        Vector2 pos = trans.anchoredPosition;
        pos.y = y;
        trans.anchoredPosition = pos;
    }
    public static void AddAnchorPosition(this RectTransform trans, Vector2 p)
    {
        Vector2 pos = trans.anchoredPosition;
        pos += p;
        trans.anchoredPosition = pos;
    }
    public static void AddAnchorPositionX(this RectTransform trans, float x)
    {
        Vector2 pos = trans.anchoredPosition;
        pos.x += x;
        trans.anchoredPosition = pos;
    }
    public static void AddAnchorPositionY(this RectTransform trans, float y)
    {
        Vector2 pos = trans.anchoredPosition;
        pos.y += y;
        trans.anchoredPosition = pos;
    }
    public static Vector3 GetRotateAroundResult(this Transform trans, Vector3 rotatePoint, Vector3 axis, float angle)
	{
		return Quaternion.AngleAxis(angle, axis) * (trans.position - rotatePoint) + rotatePoint;
	}
    public static string GetMasterAudioKeySound(this Transform trans, string sound)
    {
        return sound + trans.gameObject.GetHashCode().ToString();
    }
    public static string GetMasterAudioKeySound(this Transform trans,GameObject gameobject,string sound)
    {
        return sound + gameobject.GetHashCode().ToString();
    }
    public static string GetMasterAudioKeySound(this Transform trans,string key, string sound)
    {
        return sound + key;
    }
    public static T SearchComponent<T>(this Transform transform, GameObject go, string name, bool includeInactive = false) where T : Component
    {
        T[] componentsInChildren = go.transform.GetComponentsInChildren<T>(includeInactive);
        for (int i = 0; i < componentsInChildren.Length; i++)
        {
            T _t = componentsInChildren[i];
            if (_t.name == name)
            {
                return _t as T;
            }
        }
        return null;
    }
}
