# UGUITableView
An iOS Like Table View in UGUI

支持纵向和横向的列表，动态重用加载的UI列表。代码初始化时需要设置委托方法。eg：

    //唤醒先初始化委托
    void Awake() {
        //一共有多少行数据，t==tbView，下同
        tbView.delegateNumberOfCells = (t) => {
            return dataList.Count;
        };
        //第i行的cell的高度
        tbView.delegateSizeOfIndex = (t, i) => {
            //奇数行和偶数行分别显示不同的高度，对应不同的样式
            return i % 2 == 0 ? 160 : 320;
        };
        //返回第i行的cell（RectTransform）
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
        //字符标识不同的cell样式
        tbView.delegateIdentifierOfIndex = (t, i) => {
            //奇数行和偶数行分别显示不同的高度，对应不同的样式。这里的字符串分别用来标识不同的样式，方便Dequeue时查找对应的cell
            return i % 2 == 0 ? "Short" : "High";
        };
    }
    
刷新列表的数据的方法是ReloadData(idx)
其中idx有不同的控制，eg：
    
    //每行数据加100
    public void OnAdd100() {
        for (int i = 0; i < 100; i++) {
            dataList[i] += 100;
        }
        tbView.ReloadData(-2);
    }

    //滚到顶部
    public void OnToTop() {
        tbView.ReloadData(-1);
    }

    //滚到第51行
    public void OnTo50() {
        tbView.ReloadData(51);
    }
