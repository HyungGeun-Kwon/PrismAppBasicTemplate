namespace PrismInspectionAppTemplate.Core.Service.Bootstrap
{
    public class BootstrapperInfo
    {
        public string Title { get; set; }         // 부트스트래퍼 제목
        public int ProgressPercent { get; set; }  // 진행률

        public BootstrapperInfo() { }
        public BootstrapperInfo(string title, int progressPercent = 0)
        {
            Title = title;
            ProgressPercent = progressPercent;
        }

        /// <summary>
        /// 진행률 업데이트
        /// </summary>
        /// <param name="totalCount">Bootstrapper 전체 수</param>
        /// <param name="nowIndex">현재 Index. 0부터 시작됨.</param>
        public void SetProgressPercent(int totalCount, int nowIndex)
        {
            ProgressPercent = (nowIndex + 1) * 100 / totalCount;
        }
    }
}
