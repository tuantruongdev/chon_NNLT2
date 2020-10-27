using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Which_Programing_Should_I_Learn
{
    public partial class frmMain : Form
    {
        public static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
    "đ",
    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
    "í","ì","ỉ","ĩ","ị",
    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
    "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
    "d",
    "e","e","e","e","e","e","e","e","e","e","e",
    "i","i","i","i","i",
    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
    "u","u","u","u","u","u","u","u","u","u","u",
    "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }


        List<MyQuestion> questionList = new List<MyQuestion>();
        private Stack<MyAnswer> myAnswers = new Stack<MyAnswer>();
        private Dictionary<String, String> description = new Dictionary<string, string>();
        private int currentQuestion = -1;
        //keywords
        private List<String> key = new List<string>()
        {
            "why", "which_platform", "which_mobile_os", "web", "want_to_work_for",
            "think_about_microsoft", "try_something_new", "favourite_toy",
            "prefer_to_learn", "car"
        };
        private MyProlog prolog;
        private const String prologFilePath = @"..\..\Prolog_Code.pl";
        public frmMain()
        {
            InitializeComponent();
            // Init & Load prolog file
            prolog = new MyProlog();
            prolog.LoadFile(prologFilePath);
            // Build List question
            buildListQuestion();
        }

        private void buildListQuestion()
        {
            // 0
            questionList.Add(new MyQuestion("Tại sao bạn lại muốn học lập trình?",
                new List<string>() { "Tìm cho con của tôi", "Không biết nữa", "Kiếm tiền",
                "Học cho vui", "Cảm thấy lập trình thú vị", "Nâng cao trình độ bản thân"}));
            // 1
            questionList.Add(new MyQuestion("Nền tảng nào?",
                new List<string>() { "Không quan trọng", "Gaming", "Mobile", "Facebook",
                "Google", "Microsoft", "Apple", "Web", "Doanh nghiệp"}));
            // 2
            questionList.Add(new MyQuestion("Hệ điều hành nào?", new List<string>() { "IOS", "Android" }));
            // 3
            questionList.Add(new MyQuestion("Backend hay front end?", new List<string>() { "Front end", "Back end" }));
            // 4
            questionList.Add(new MyQuestion("Tôi muốn làm cho...", new List<string>() { "Khởi nghiệp", "Công ty lâu năm" }));
            // 5
            questionList.Add(new MyQuestion("Bạn nghĩ sao về Microsoft?",
                new List<string>() { "Tôi là fan của microsoft", "Không tồi", "Không thích" }));
            // 6
            questionList.Add(new MyQuestion("Bạn có thích những thứ mới mẻ, Tiềm năng to lớn, nhưng mà chưa phát triển?",
                new List<string>() { "Có", "Không" }));
            // 7
            questionList.Add(new MyQuestion("Đồ chơi bạn thích là gì?",
                new List<string>() { "Lego", "Búp bê", "Bóng đá" }));
            // 8
            questionList.Add(new MyQuestion("Tôi muốn học theo cách...",
                new List<string>() { "Cách dễ nhất", "Cách tốt nhất", "Cách rất khó", "Cách khó nhất có thể" }));
            // 9
            questionList.Add(new MyQuestion("Xe tự động hay xe số sàn?",
                new List<string>() { "Tự động", "Số sàn" }));

            description.Add("PYTHON", "PYTHON là ngôn ngữ dành cho bạn!! \r\nĐược biết là ngôn ngữ dành cho người mới bắt đầu\r\nCực đễ để bắt đầu học");
            description.Add("JAVA", "JAVA  là ngôn ngữ dành cho bạn!! \r\nMột trong những ngôn ngữ thích hợp và có mức lương cao nhất\r\nSlogan: viết một lần, chạy mọi nơi");
            description.Add("C", "C  là ngôn ngữ dành cho bạn!! \r\nbậc cha anh của ngôn ngữ lập trình hiện đại\r\nMột trong những ngôn ngữ 'già'nhất và được sử dụng nhiều nhất");
            description.Add("C++", "C++  là ngôn ngữ dành cho bạn!! \r\nPhiên bản cải tiến của C và có thêm rất nhiều cải tiến\r\nKhuyến khích khi học cần có người hướng dẫn cho bạn");
            description.Add("JAVASCRIPT", "JAVASCRIPT  là ngôn ngữ dành cho bạn!! \r\nMột trong những ngôn ngữ kịch bản chạy trên web phổ biến nhất\r\nNên học khi bạn có liên quan đến Front-end");
            description.Add("C#", "C#  là ngôn ngữ dành cho bạn!! \r\nMột trong những lựa chọn phổ biến để tạo ứng dụng desktop, web sử dụng farmework .Net Của Microsoft\r\nGiống java về một số cú pháp và một số tính năng");
            description.Add("RUBY", "RUBY  là ngôn ngữ dành cho bạn!! \r\nĐược biết là một trong nhữg framework dành cho web, Ruby on Rails\r\nTập trung giải quyết vấn đề");
            description.Add("PHP", "PHP là ngôn ngữ dành cho bạn!! \r\nPhù hợp để xây dựng websites đơn giản trong một khoảng thời gian ngắn\r\nHỗ trợ hầu hết các máy chủ từ rẻ đếnd đắt");
            description.Add("OBJECTIVE-C", "OBJECTIVE-C là ngôn ngữ dành cho bạn!! \r\nNgôn ngữ chính của Apple dùng cho OSX/IOS\r\nChỉ chọn nó khi bạn muốn tập trung vào IOS / OSX!");
        }

        private void BindQuestion(int index)
        {
            HideRadioButton();
            lbQuestion.Text = questionList[index].Question;
            for (int i = 0; i < questionList[index].Answers.Count; i++)
            {
                RadioButton c = (RadioButton)this.Controls.Find("rd" + (i + 1), true).FirstOrDefault();
                c.Text = questionList[index].Answers[i];
                c.Visible = true;
            }
        }

        private int QuestionControl(int index, String ans)
        {
            int current = -1;
            switch (index)
            {

                case 0:
                    if (ans.Contains("tiền")) { BindQuestion(1); current = 1; }
                    else if (ans.Contains("vui") || ans.Contains("vị") || ans.Contains("thân")) { BindQuestion(8); current = 8; }
                    break;
                case 1:
                    if (ans.Contains("mobile")) { BindQuestion(2); current = 2; }
                    else if (ans.Contains("web")) { BindQuestion(3); current = 3; }
                    else if (ans.Contains("nghiệp")) { BindQuestion(5); current = 5; }
                    break;
                case 2:
                    break;
                case 3:
                    if (ans.Contains("back_end")) { BindQuestion(4); current = 4; }
                    break;
                case 4:
                    if (ans.Contains("khởi")) { BindQuestion(6); current = 6; }
                    else if (ans.Contains("doanh")) { BindQuestion(5); current = 5; }
                    break;
                case 5:
                    break;
                case 6:
                    if (ans.Contains("Không")) { BindQuestion(7); current = 7; }
                    break;
                case 7:
                    break;
                case 8:
                    if (ans.Contains("rất")) { BindQuestion(9); current = 9; }
                    break;
                case 9:
                    break;
            }
            return current;
        }

        private String GetResult(String ans)
        {
            return ans.Replace(" ", "_").Replace("'", "").ToLower();
        }

        private void HideRadioButton()
        {
            rd1.Visible = false;
            rd2.Visible = false;
            rd3.Visible = false;
            rd4.Visible = false;
            rd5.Visible = false;
            rd6.Visible = false;
            rd7.Visible = false;
            rd8.Visible = false;
            rd9.Visible = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Visible = false;
            gpQuestion.Visible = true;
            lbTitle.Location = new Point(lbTitle.Location.X, lbTitle.Location.Y - 115);
            currentQuestion = 0;
            BindQuestion(0);
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            btnStart.Visible = true;
            gpQuestion.Visible = false;
            lbTitle.Location = new Point(lbTitle.Location.X, lbTitle.Location.Y + 115);
            myAnswers.Clear();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (rd1.Checked) { myAnswers.Push(new MyAnswer(currentQuestion, GetResult(rd1.Text))); currentQuestion = QuestionControl(currentQuestion, GetResult(rd1.Text)); }
            else if (rd2.Checked) { myAnswers.Push(new MyAnswer(currentQuestion, GetResult(rd2.Text))); currentQuestion = QuestionControl(currentQuestion, GetResult(rd2.Text)); }
            else if (rd3.Checked) { myAnswers.Push(new MyAnswer(currentQuestion, GetResult(rd3.Text))); currentQuestion = QuestionControl(currentQuestion, GetResult(rd3.Text)); }
            else if (rd4.Checked) { myAnswers.Push(new MyAnswer(currentQuestion, GetResult(rd4.Text))); currentQuestion = QuestionControl(currentQuestion, GetResult(rd4.Text)); }
            else if (rd5.Checked) { myAnswers.Push(new MyAnswer(currentQuestion, GetResult(rd5.Text))); currentQuestion = QuestionControl(currentQuestion, GetResult(rd5.Text)); }
            else if (rd6.Checked) { myAnswers.Push(new MyAnswer(currentQuestion, GetResult(rd6.Text))); currentQuestion = QuestionControl(currentQuestion, GetResult(rd6.Text)); }
            else if (rd7.Checked) { myAnswers.Push(new MyAnswer(currentQuestion, GetResult(rd7.Text))); currentQuestion = QuestionControl(currentQuestion, GetResult(rd7.Text)); }
            else if (rd8.Checked) { myAnswers.Push(new MyAnswer(currentQuestion, GetResult(rd8.Text))); currentQuestion = QuestionControl(currentQuestion, GetResult(rd8.Text)); }
            else if (rd9.Checked) { myAnswers.Push(new MyAnswer(currentQuestion, GetResult(rd9.Text))); currentQuestion = QuestionControl(currentQuestion, GetResult(rd9.Text)); }
            if (currentQuestion == -1)
            {
                String query = "";
                String history = "";
                while (myAnswers.Count > 0)
                {
                    MyAnswer ma = myAnswers.Pop();
                    query = RemoveUnicode(key[ma.QuestionIndex] + "('" + ma.Answer + "'), " + query);
                   // MessageBox.Show(query);
                    history = "---------------------------------------------------\r\n" + history;
                    history = "[Q] " + ma.Answer + "\r\n" + history;
                    history = "[A] " + questionList[ma.QuestionIndex].Question + "\r\n" + history;
                }
                query = query.Substring(0, query.Length - 2);
                query = "language(X, " + query + ").";
                try
                {
                    String result = description[prolog.GetResult(query).ToUpper()];
                    MessageBox.Show(result, "này!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show("Hiển thị lịch sử câu hỏi?", "Xem lịch sử", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        history += "System result:\r\n" + result;
                        new frmHistory(history).ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                reset();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (myAnswers.Count > 0)
            {
                currentQuestion = myAnswers.Peek().QuestionIndex;
                BindQuestion(currentQuestion);
                myAnswers.Pop();
            }
            else
            {

            }
        }
    }
}
