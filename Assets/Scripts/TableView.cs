using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

class TableViewGroup
{
	public Dictionary<int, RectTransform> visibilityCellQueue = new Dictionary<int, RectTransform>();
	public List<RectTransform> invisibilityCellQueue = new List<RectTransform>();

	~TableViewGroup()
	{
		visibilityCellQueue.Clear();
		visibilityCellQueue = null;
		invisibilityCellQueue.Clear();
		invisibilityCellQueue = null;
	}

    public void QueueInvisible()
    {
        foreach(int i in visibilityCellQueue.Keys) {
            RectTransform trans = visibilityCellQueue[i];
            invisibilityCellQueue.Add(trans);
            trans.gameObject.SetActive(false);
        }
        visibilityCellQueue.Clear();
    }
}

public class TableView : ScrollRect
{
	public const string DEFAULT_IDENTIFIER = "default.identifier";

	public delegate int NumberOfCells(TableView tbView);
	public delegate float SizeOfIndex(TableView tbView, int index);
	public delegate RectTransform TransformOfIndex(TableView tbView, int index);
	public delegate string IdentifierOfIndex(TableView tbView, int index);
	/// <summary>
	/// 返回行数
	/// </summary>
	public NumberOfCells delegateNumberOfCells = null;
	/// <summary>
	/// 说明：返回第i行cell的高度（垂直），或宽度（水平）
	/// 参数
	/// t: TableView
	/// i: int 表示第几行
	/// </summary>
	public SizeOfIndex delegateSizeOfIndex = null;
	/// <summary>
	/// 说明：返回第i行cell的RectTransform
	/// 参数
	/// t: TableView
	/// i: int 表示第几行
	/// </summary>
	public TransformOfIndex delegateTransformOfIndex = null;
	/// <summary>
	/// 说明：返回第i行cell的标识符
	/// 参数
	/// t: TableView
	/// i: int 表示第几行
	/// </summary>
	public IdentifierOfIndex delegateIdentifierOfIndex = null;

	int extraBuffer = 2;

	private Rect[] rects;
	private Dictionary<string, TableViewGroup> groupDict = new Dictionary<string, TableViewGroup>();
	private int numberOfCells = 0;
	private int minVisibleIndex = 0;
	private int maxVisibleIndex = 0;

	protected override void OnDestroy()
	{
		delegateNumberOfCells = null;
		delegateSizeOfIndex = null;
		delegateTransformOfIndex = null;
		delegateIdentifierOfIndex = null;

		base.OnDestroy();
	}

	protected override void Start()
	{
        base.Start();
		onValueChanged.AddListener(OnMove);
	}

	bool IsIdentifierExist(string identifier)
	{
		return groupDict.ContainsKey(identifier + "_v");
	}

	void OnMove(Vector2 value)
	{
        //if (horizontal && (value.x < 0 || value.x > 1)) return;
        //if (vertical && (value.y < 0 || value.y > 1)) return;

        if (numberOfCells == 0) return;

		UpdateMinMaxVisibleIndex();
	}

	private void UpdateMinMaxVisibleIndex()
	{
		Vector2 minMaxVisibleIndexes = new Vector2(minVisibleIndex, maxVisibleIndex);
		Vector2 minMaxIndexes = GetMinMaxVisibleIndex();
		int minIndex = (int)minMaxIndexes.x;
		int maxIndex = (int)minMaxIndexes.y;

		int minAddIndex, maxAddIndex, minRemoveIndex, maxRemoveIndex;

		Vector2 intersectRange = minMaxVisibleIndexes.IntersectionRange(minMaxIndexes);
		if (intersectRange.y == 0 && minIndex != maxIndex && minIndex != minVisibleIndex && minVisibleIndex != maxVisibleIndex)
		{
			minAddIndex = minIndex;
			maxAddIndex = maxIndex;
			minRemoveIndex = minVisibleIndex;
			maxRemoveIndex = maxVisibleIndex;
		}
		else
		{
			// for remove index
			// -------------minV-------------maxV--------
			// ------minI----------maxI------------------
			if (intersectRange.x == minVisibleIndex)
			{
				minRemoveIndex = (int)(intersectRange.x + intersectRange.y + 1);
				maxRemoveIndex = maxVisibleIndex;
			}
			else
			{
				minRemoveIndex = minVisibleIndex;
				maxRemoveIndex = (int)(intersectRange.x - 1);
			}

			// for add index
			// -------------minI-------------maxI--------
			// ------minV----------maxV------------------
			if (intersectRange.x == minIndex)
			{
				minAddIndex = (int)(intersectRange.x + intersectRange.y + 1);
				maxAddIndex = maxIndex;
			}
			else
			{
				minAddIndex = minIndex;
				maxAddIndex = (int)(intersectRange.x - 1);
			}
		}

		minVisibleIndex = minIndex;
		maxVisibleIndex = maxIndex;

		for (int i = minRemoveIndex; i <= maxRemoveIndex; i++)
		{
			RemoveCellAtIndex(i);
		}
		for (int i = minAddIndex; i <= maxAddIndex; i++)
		{
			AddCellAtIndex(i);
		}
	}

	private void AddCellAtIndex(int index)
	{
		if (index >= numberOfCells || index < 0) return;
		string identifier = GetIdentifierForIndex(index);

		if (groupDict[identifier].visibilityCellQueue.ContainsKey(index) == false)
		{
			Rect rect = rects[index];
			RectTransform trans = delegateTransformOfIndex(this, index);
			//trans.anchorMin = new Vector2(0.5f, 0.5f);
			//trans.anchorMax = new Vector2(0.5f, 0.5f);
			trans.SetParent(content);
			//trans.anchoredPosition = new Vector2(rect.x, rect.y);
			trans.localScale = Vector3.one;
			trans.SetLocalPositionZ(0);

			if (vertical)
			{
				trans.anchoredPosition = new Vector2(rect.x, rect.y - rect.height / 2f);
				trans.anchorMin = new Vector2(0f, 1f);
				trans.anchorMax = new Vector2(1f, 1f);
				trans.pivot = new Vector2(0.5f, 0.5f);
				Vector2 v = trans.offsetMin;
				v.x = 0;
				trans.offsetMin = v;
				v = trans.offsetMax;
				v.x = 0;
				trans.offsetMax = v;
			}
			else
			{
				trans.anchoredPosition = new Vector2(rect.x + rect.width / 2f, rect.y);
				trans.anchorMin = new Vector2(0f, 0.5f);
				trans.anchorMax = new Vector2(0f, 0.5f);
				trans.pivot = new Vector2(0.5f, 0.5f);
			}

			groupDict[identifier].visibilityCellQueue.Add(index, trans);

			trans.gameObject.SetActive(true);
		}
	}

	private void RemoveCellAtIndex(int index)
	{
		string identifier = GetIdentifierForIndex(index);
		if (groupDict[identifier].visibilityCellQueue.ContainsKey(index) == true)
		{
			RectTransform trans = groupDict[identifier].visibilityCellQueue[index];
			groupDict[identifier].invisibilityCellQueue.Add(trans);
			groupDict[identifier].visibilityCellQueue.Remove(index);
			trans.gameObject.SetActive(false);
		}
	}

	private int IndexAtOffset(float offset)
	{
		int minIndex = 0;
		int maxIndex = numberOfCells - 1;
		maxIndex = maxIndex < 0 ? 0 : maxIndex;
		int index = (maxIndex + minIndex) / 2;

		if (vertical)
		{
			while (minIndex < maxIndex)
			{
				float indexY = rects[index].y;
				float nextY = rects[index + 1].y;

				if (indexY >= offset && nextY < offset) break;
				else if (nextY >= offset) minIndex = index + 1;
				else maxIndex = index;

				index = (maxIndex + minIndex) / 2;
			}
		}
		else
		{
			while (minIndex < maxIndex)
			{
				float indexX = -rects[index].x;
				float nextX = -rects[index + 1].x;

				if (indexX >= offset && nextX < offset) break;
				else if (nextX >= offset) minIndex = index + 1;
				else maxIndex = index;

				index = (maxIndex + minIndex) / 2;
			}
		}
		return index;
	}

	private Vector2 GetMinMaxVisibleIndex()
	{
		RectTransform trans = transform as RectTransform;
		Vector2 offset = content.anchoredPosition;

		float viewWidth = trans.rect.width;
		float viewHeight = trans.rect.height;

		int minIndex = vertical ? IndexAtOffset(-offset.y) : IndexAtOffset(offset.x);
		int maxIndex = vertical ? IndexAtOffset(-offset.y - viewHeight) : IndexAtOffset(offset.x - viewWidth);

		int boundMinIndex = 0;
		int boundMaxIndex = numberOfCells - 1;// Mathf.Max(0, numberOfCells - 1);
		minIndex = minIndex - extraBuffer / 2;
		minIndex = minIndex < boundMinIndex ? boundMinIndex : minIndex;
		maxIndex = maxIndex + extraBuffer / 2;
		maxIndex = maxIndex > boundMaxIndex ? boundMaxIndex : maxIndex;

		return new Vector2(minIndex, maxIndex);
	}

    /// <summary>
    /// 重新加载数据+
    /// </summary>
    /// <param name="startIndex">重新加载后跳转到第startIndex行，如：10，跳转到第10行。另：-1，跳转到第0行，并执行反弹动画；-2，在当前行刷新</param>
    public void ReloadData(int startIndex = -1, bool cleanCell = false)
    {
        if (delegateNumberOfCells == null) return;

        RectTransform trans = transform as RectTransform;
        float viewWidth = trans.rect.width;
        float viewHeight = trans.rect.height;
        
        if (cleanCell) {
            groupDict.Clear();
            content.Clear();
        }
        else {
            foreach(string identifier in groupDict.Keys) {
                groupDict[identifier].QueueInvisible();
            }
        }
		numberOfCells = delegateNumberOfCells(this);

		rects = new Rect[numberOfCells];

		float offsetX = 0f;
		float offsetY = 0f;
		float width = 0;
		float x = 0;
		float height = 0;
		float y = 0;
		Vector2 contentPos = content.anchoredPosition;
		Vector2 contentSize = content.sizeDelta;

		System.Action<int> createIdentifierGroup = null;
		if (delegateIdentifierOfIndex == null)
		{
			if(groupDict.ContainsKey(DEFAULT_IDENTIFIER) == false) groupDict[DEFAULT_IDENTIFIER] = new TableViewGroup();
		}
		else
		{
			createIdentifierGroup = (i) => {
				string identifier = delegateIdentifierOfIndex(this, i);
				if (groupDict.ContainsKey(identifier) == false) groupDict[identifier] = new TableViewGroup();
			};
		}

		if (vertical)
		{
			for (int i = 0; i < numberOfCells; i++)
			{
				height = delegateSizeOfIndex(this, i);
				rects[i] = new Rect(0, -y, viewWidth, height);
				y += height;
				if (i < startIndex) offsetY += height;
				if (createIdentifierGroup != null) createIdentifierGroup(i);
			}
			contentSize.y = y;
		}
		else
		{
			for (int i = 0; i < numberOfCells; i++)
			{
				width = delegateSizeOfIndex(this, i);
				rects[i] = new Rect(x, 0, width, viewHeight);
				x += width;
				if (i < startIndex) offsetX += width;
				if (createIdentifierGroup != null) createIdentifierGroup(i);
			}
			contentSize.x = x;
		}
		content.sizeDelta = contentSize;

		if (startIndex >= 0)
		{
			if (vertical) contentPos.y = offsetY;
			else contentPos.x = offsetX;
			content.anchoredPosition = contentPos;
		}
		else if (startIndex == -1)
		{
			if (vertical) contentPos.y = -viewHeight;
			else contentPos.x = viewWidth;
			content.anchoredPosition = contentPos;
		}

		Vector2 indexes = GetMinMaxVisibleIndex();
		minVisibleIndex = (int)indexes.x;
		maxVisibleIndex = (int)indexes.y;

		if (numberOfCells > 0)
		{
			for (int i = minVisibleIndex; i <= maxVisibleIndex; i++)
			{
				AddCellAtIndex(i);
			}
		}
	}

	string GetIdentifierForIndex(int index)
	{
		return delegateIdentifierOfIndex == null ? DEFAULT_IDENTIFIER : delegateIdentifierOfIndex(this, index);
	}

	public RectTransform DequeueReusabelCell(int index)
	{
		string identifier = GetIdentifierForIndex(index);
		List<RectTransform> invisibilityCellQueue = groupDict[identifier].invisibilityCellQueue;
		int count = invisibilityCellQueue.Count;
		if (count > 0)
		{
			RectTransform trans = invisibilityCellQueue[count - 1];
			invisibilityCellQueue.RemoveAt(count - 1);
			return trans;
		}

		return null;
	}
}