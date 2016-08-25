using Android.OS;
using Android.App;
using Android.Widget;
using Android;
using Android.Views;
using Android.Content;
using System;

namespace Triviality
{
    [Activity(Label = "Results")]
    public class ResultActivity : Activity
	{

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // int score = Intent.GetIntExtra("Score",-1);
            SetContentView(Resource.Layout.ResultLayout);
            //get rating bar object
            RatingBar bar = (RatingBar)FindViewById(Resource.Id.ratingBar1);
            bar.NumStars = 5;
            bar.StepSize = 0.5f;
            //get text view
            TextView t = (TextView)FindViewById(Resource.Id.textResult);
            //get score
            Bundle b = Intent.Extras;
            int score = b.GetInt("Score");
            //QuizActivity k = new QuizActivity();
            //int score = k.score;
            //display score
            bar.Rating = score;
            if (score <= 2)
            { t.Text = "Oops, try again bro, keep learning";
            }
            if (score > 3 && score <= 4 )
            { t.Text = "Hmmmm.. maybe you have been reading a lot of Python quiz";

            }
            if (score >= 5)
            {
                t.Text = "Who are you?Are you a geek in python??";

            }
            //switch (score)
            //{
            //         case 0:
            //case 1:
            //case 2: t.Text = "Opps, try again bro, keep learning";
            //	break;
            //case 3:
            //case 4:t.Text = "Hmmmm.. maybe you have been reading a lot of JasaProgrammer quiz";
            //	break;
            //case 5:t.Text = "Who are you? A student in JP???";
            //	break;
            //}
            Button btnGotoQuiz = FindViewById<Button>(Resource.Id.btnGotoQuiz);
            btnGotoQuiz.Click += btnGotoQuiz_Click;
        }

         void btnGotoQuiz_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(QuizActivity));
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.ResultMenu, menu);
			return true;
		}
	}
}

