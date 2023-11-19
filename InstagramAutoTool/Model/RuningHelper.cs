namespace InstagramAutoTool.Model
{
    public class RuningHelper
    {
        private int _follow;
        private int _like;
        private int _comment;
        private int _second;
        private int _commentDownload;
        private int _imageDownload;
        
        public RuningHelper(int follow, int like, int comment, int second)
        {
            _follow = follow;
            _like = like;
            _comment = comment;
            _second = second;
        }

        
        
        public RuningHelper()
        {
            _follow = 0;
            _like = 0;
            _comment = 0;
            _second = 0;
            _imageDownload = 0;
            _commentDownload = 0;
        }


        public void Reset()
        {
            _follow = 0;
            _like = 0;
            _comment = 0;
            _second = 0;
            _imageDownload = 0;
            _commentDownload = 0;
        }
        
        public int Follow
        {
            get => _follow;
            set => _follow = value;
        }

        public int Like
        {
            get => _like;
            set => _like = value;
        }

        public int Comment
        {
            get => _comment;
            set => _comment = value;
        }

        public int Second
        {
            get => _second;
            set => _second = value;
        }

        public int CommentDownload
        {
            get => _commentDownload;
            set => _commentDownload = value;
        }

        public int ImageDownload
        {
            get => _imageDownload;
            set => _imageDownload = value;
        }
    }
}