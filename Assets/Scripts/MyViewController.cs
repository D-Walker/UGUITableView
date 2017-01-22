using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyViewController : MonoBehaviour {
    [SerializeField] TableView tbView;
    [SerializeField] RectTransform cellShort;
    [SerializeField] RectTransform cellHigh;

    List<int> dataList = new List<int>();

    void Awake() {
        tbView.delegateNumberOfCells = (t) => {
            return dataList.Count;
        };
        tbView.delegateSizeOfIndex = (t, i) => {
            //奇数行和偶数行分别显示不同的高度，对应不同的样式
            return i % 2 == 0 ? 160 : 320;
        };
        tbView.delegateTransformOfIndex = (t, i) => {
            //先从缓存队列中访问第i行是否有可用的cell
            RectTransform cell = t.DequeueReusabelCell(i);
            //没有可用的cell时，实例一个
            if (cell == null) {
                //奇数行和偶数行分别对应不同的样式，分别初始化，然后存入缓存队列
                if (i % 2 == 0) {
                    cell = Instantiate(cellShort);
                }
                else {
                    cell = Instantiate(cellHigh);
                }
            }
            if (i % 2 == 0) {
                cell.GetComponentInChildren<Text>().text = dataList[i].ToString();
            }
            else {
                cell.GetComponentInChildren<Text>().text = dataList[i].ToString();
            }
            return cell;
        };
        tbView.delegateIdentifierOfIndex = (t, i) => {
            //奇数行和偶数行分别显示不同的高度，对应不同的样式。这里的字符串分别用来标识不同的样式，方便Dequeue时查找对应的cell
            return i % 2 == 0 ? "Short" : "High";
        };
    }

	void Start () {
        for (int i = 0; i < 100; i++) {
            dataList.Add(i);
        }
        tbView.ReloadData(-1);
	}
	
    public void OnAdd100() {
        for (int i = 0; i < 100; i++) {
            dataList[i] += 100;
        }
        tbView.ReloadData(-2);
    }

    public void OnToTop() {
        tbView.ReloadData(-1);
    }

    public void OnTo50() {
        tbView.ReloadData(51);
    }
}
