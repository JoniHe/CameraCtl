
  /// <summary>
  /// 找线工具
  /// </summary>
  /// <param name="startX"></param>
  /// <param name="startY"></param>
  /// <param name="endX"></param>
  /// <param name="endY"></param>
  /// <returns></returns>
  private CogFindLineTool CreateFindLineTool(double startX, double startY, double endX, double endY)
  {
    CogFindLineTool findLine = new CogFindLineTool();
    //卡尺输入参数
    //数量
    findLine.RunParams.NumCalipers = 100;
    //搜索长度
    findLine.RunParams.CaliperSearchLength = 60;
    //忽略点数
    findLine.RunParams.NumToIgnore = 10;
    //起点
    findLine.RunParams.ExpectedLineSegment.StartX = startX;
    findLine.RunParams.ExpectedLineSegment.StartY = startY;
    //终点
    findLine.RunParams.ExpectedLineSegment.EndX = endX;
    findLine.RunParams.ExpectedLineSegment.EndY = endY;
    findLine.RunParams.ExpectedLineSegment.SelectedColor = CogColorConstants.Blue;
    return findLine;
  }