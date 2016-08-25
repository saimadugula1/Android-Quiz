using Android.OS;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Android;
using Android.Views;
using System;
using Android.Content;

namespace Triviality
{
	[Activity (Label = "Python Quiz", MainLauncher = true, Icon = "@drawable/icon")]
	public class QuizActivity : Activity
	{
		List<Question> quesList;
		public int score;
		public int qid=0;
        string answer;
		Question currentQ;
		TextView txtQuestion;
		RadioButton rda, rdb, rdc;
		Button butNext;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.QuizLayout);
			DbHelper db=new DbHelper(this);
			quesList=db.getAllQuestions();
			currentQ=quesList[qid];
			txtQuestion=(TextView)FindViewById(Resource.Id.textView1);
			rda=(RadioButton)FindViewById(Resource.Id.radio0);
			rdb=(RadioButton)FindViewById(Resource.Id.radio1);
			rdc=(RadioButton)FindViewById(Resource.Id.radio2);
			butNext=(Button)FindViewById(Resource.Id.button1);
            Button btnSubmit = FindViewById<Button>(Resource.Id.btnSubmit);
            btnSubmit.Click += btnSubmit_Click;
            butNext.Click += butNext_Click;
            setQuestionView();
		}

         void btnSubmit_Click(object sender, EventArgs e)
        {
            var ResultActivity = new Intent(this, typeof(ResultActivity));
            ResultActivity.PutExtra("Score", score);
            StartActivity(ResultActivity);


          //  StartActivity(typeof(ResultActivity));
        }

        void  butNext_Click(object sender, EventArgs e)
        {
            DbHelper db = new DbHelper(this);
            quesList = db.getAllQuestions();
            int Count = quesList.Count;
            currentQ = quesList[qid];
       
         
                txtQuestion.Text = currentQ.getQUESTION();
            rda.Text = currentQ.getOPTA();
            rdb.Text = currentQ.getOPTB();
            rdc.Text = currentQ.getOPTC();
            answer = currentQ.getANSWER();
            if  (rda.Checked==true && rda.Text== answer)
            {
                score++;
            }
            if (rdb.Checked == true && rdb.Text == answer)
            {
                score++;
            }
            if (rdc.Checked == true && rdc.Text == answer)
            {
                score++;
              
            }

            int scr = score;
           
            if (qid <( Count-1)) {
                qid++;

            }
            else {
                //var ResultActivity = new Intent(this, typeof(ResultActivity));
                //ResultActivity.PutExtra("Score", score);
                //StartActivity(ResultActivity);


                //StartActivity(typeof(ResultActivity));
               
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Congratulations");
                alert.SetPositiveButton("You are done with quiz, please submit your answers", (senderAlert, args) => {
                   
                });
                
                RunOnUiThread(() => {
                    alert.Show();
                });
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.QuizMenu, menu);
			return true;
		}

		private void setQuestionView()
		{
            currentQ = quesList[qid];
            txtQuestion.Text = currentQ.getQUESTION();
			rda.Text = currentQ.getOPTA ();
			rdb.Text = currentQ.getOPTB ();
			rdc.Text = currentQ.getOPTC ();
            if (rda.Checked == true && rda.Text == answer)
            {
                score++;
            }
        }
	}
}


