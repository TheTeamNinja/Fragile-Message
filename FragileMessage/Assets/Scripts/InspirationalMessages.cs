using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspirationalMessages {

	public static string GetMessage(bool newRecord)
	{
		if (newRecord) {
			return inspirationalMessages[Random.Range(0, inspirationalMessages.Length)];
		}
		else
		{
			return tryAgainMessages[Random.Range(0, tryAgainMessages.Length)];
		}
	}

	private static string[] tryAgainMessages =
	{
		"Giving up is the only sure way to fail. Try Again!",
		"Everything you want is on the other side of fear. Try Again!",
		"Success is most often achieved by those who don't know that failure is inevitable. Try Again!",
		"Only those who dare to fail greatly can ever achieve greatly. Try Again!",
		"The phoenix must burn to emerge. Try Again!",
		"There is no failure except in no longer trying. Try Again!",
		"I have not failed. I've just found 10,000 ways that won't work. Try Again!",
		"Failures are finger posts on the road to achievement. Try Again!",
		"It’s not how far you fall, but how high you bounce that counts. Try Again!"
	};

	private static string[] inspirationalMessages =
	{
		"The Way Get Started Is To Quit Talking And Begin Doing. -Walt Disney",
		"The Pessimist Sees Difficulty In Every Opportunity. The Optimist Sees Opportunity In Every Difficulty. -Winston Churchill",
		"Don’t Let Yesterday Take Up Too Much Of Today. -Will Rogers",
		"You Learn More From Failure Than From Success. Don’t Let It Stop You. Failure Builds Character. -Unknown",
		"If You Are Working On Something That You Really Care About, You Don’t Have To Be Pushed. The Vision Pulls You. -Steve Jobs",
		"People Who Are Crazy Enough To Think They Can Change The World, Are The Ones Who Do. -Rob Siltanen",
		"Failure Will Never Overtake Me If My Determination To Succeed Is Strong Enough. -Og Mandino",
		"Entrepreneurs Are Great At Dealing With Uncertainty And Also Very Good At Minimizing Risk. That’s The Classic Entrepreneur.- Mohnish Pabrai",
		"We May Encounter Many Defeats But We Must Not Be Defeated. -Maya Angelou",
		"Knowing Is Not Enough; We Must Apply. Wishing Is Not Enough; We Must Do. -Johann Wolfgang Von Goethe",
		"Imagine Your Life Is Perfect In Every Respect; What Would It Look Like? -Brian Tracy",
		"We Generate Fears While We Sit. We Overcome Them By Action. -Dr. Henry Link",
		"Whether You Think You Can Or Think You Can’t, You’re Right. -Henry Ford",
		"Security Is Mostly A Superstition. Life Is Either A Daring Adventure Or Nothing. -Helen Keller",
		"The Man Who Has Confidence In Himself Gains The Confidence Of Others. -Hasidic Proverb",
		"The Only Limit To Our Realization Of Tomorrow Will Be Our Doubts Of Today. -Franklin D. Roosevelt",
		"Creativity Is Intelligence Having Fun. -Albert Einstein",
		"What You Lack In Talent Can Be Made Up With Desire, Hustle And Giving 110% All The Time. -Don Zimmer",
		"Do What You Can With All You Have, Wherever You Are. -Theodore Roosevelt",
		"Develop An ‘Attitude Of Gratitude’. Say Thank You To Everyone You Meet For Everything They Do For You. -Brian Tracy",
		"You Are Never Too Old To Set Another Goal Or To Dream A New Dream. -C.S. Lewis",
		"To See What Is Right And Not Do It Is A Lack Of Courage. -Confucious",
		"Reading Is To The Mind, As Exercise Is To The Body. -Brian Tracy",
		"Fake It Until You Make It! Act As If You Had All The Confidence You Require Until It Becomes Your Reality. -Brian Tracy",
		"The Future Belongs To The Competent. Get Good, Get Better, Be The Best! -Brian Tracy",
		"For Every Reason It’s Not Possible, There Are Hundreds Of People Who Have Faced The Same Circumstances And Succeeded. –Jack Canfield",
		"Things Work Out Best For Those Who Make The Best Of How Things Work Out. –John Wooden",
		"A Room Without Books Is Like A Body Without A Soul. –Marcus Tullius Cicero",
		"I Think Goals Should Never Be Easy, They Should Force You To Work, Even If They Are Uncomfortable At The Time. –Michael Phelps",
		"One Of The Lessons That I Grew Up With Was To Always Stay True To Yourself And Never Let What Somebody Else Says Distract You From Your Goals. -Michelle Obama",
		"Today’s Accomplishments Were Yesterday’s Impossibilities. –Robert H. Schuller",
		"The Only Way To Do Great Work Is To Love What You Do. If You Haven’t Found It Yet, Keep Looking. Don’t Settle. –Steve Jobs",
		"You Don’t Have To Be Great To Start, But You Have To Start To Be Great. –Zig Ziglar",
		"A Clear Vision, Backed By Definite Plans, Gives You A Tremendous Feeling Of Confidence And Personal Power. –Brian Tracy",
		"There Are No Limits To What You Can Accomplish, Except The Limits You Place On Your Own Thinking. –Brian Tracy"
	};
}
