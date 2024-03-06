EXTERNAL ShowBackground(backgroundName)
EXTERNAL ShowCharacter(characterName, position)
EXTERNAL HideCharacter(characterName)
EXTERNAL PlayBGM(bgmName)
EXTERNAL PlaySFX(sfxName)
EXTERNAL RestartGame()

VAR name = ""
VAR happiness = 0
VAR title = ""

-> Start

=== Start ===
~ setTitle("hello")
~ title = name
{PlayBGM("Snowfall")}
You are playing as a young college student in your early twenties who is deeply entrenched in the digital world. You are intelligent and ambitious, you were excelling in your career thanks to your proficiency with technology. However, beneath the facade of success lies a growing sense of unease and dissatisfaction.
Your screen addiction, fueled by anxiety and depression, has taken a toll on your mental and physical well-being, leaving you feeling more drained and anxious. You have been unable to perform everyday tasks and struggle to even show up for work, but you want to change and make better habits.

* [Continue] -> Introduction

=== Introduction ===
~ setTitle("{name}'s Room, Thursday")
{ShowBackground("MessyBedroom1")}
{updateHappiness(50)}
{PlaySFX("PhonePing")}
You reach for your phone. While scrolling through notifications, you see an unexpected message from your old roommate, Sam. 
{ShowCharacter("PhoneScreen1", "mid")}
"Hey {name}, it’s been a while since we caught up! Do you want to grab coffee this weekend?"
How would you like to begin this journey? 
* [Reply to your friend, accepting the invitation to the coffee date] 
    -> ReplyToFriend
* Crawl back into bed and doom scroll 
    -> DoomScroll

=== ReplyToFriend ===
You text back a response that marks the beginning of a transformative journey: 
{HideCharacter("PhoneScreen1")}
{ShowCharacter("PhoneScreen2", "mid")}
{PlaySFX("PhoneTexting")}
“Hey! It’s been too long. Coffee sounds great! I’ll see you this weekend!” 
{HideCharacter("PhoneScreen2")}
With a deep breath, you close your eyes and take a deep breath. You gently place your phone facedown on the table, its screen now devoid of distractions. In that simple gesture lies a quiet act of defiance – a symbolic declaration of intent to reclaim control over your own life. 

* [Continue to next day] -> Part1

=== DoomScroll ===
{ShowCharacter("PhoneScreen4", "mid")}
{PlayBGM("Desolate")}
You begin scrolling through your social media feeds, mindlessly consuming post after post. At first, the endless stream of content provides a sense of distraction, but as time goes on, a growing sense of unease creeps in.
With each swipe and tap, you feel a disconnect from the real world. The problems that once seemed so pressing now fade into insignificance, replaced by a superficial world of curated images and filtered updates.
{updateHappiness(-20)}
Hours pass by unnoticed as you lose yourself in the digital abyss. Your phone becomes an extension of yourself, a constant companion that isolates you from the outside world.
~ setTitle("{name}'s Room, Thursday Night")
As the night wears on, you realize that you have ignored your friend's messages. A wave of guilt washes over you, but you are unable to pull yourself away from the screen. The allure of social media has become too strong.
{updateHappiness(-20)}
~ setTitle("{name}'s Room, Friday")
Finally, as the first rays of dawn break, you set aside your phone. But the sense of emptiness and isolation lingers. You have spent the entire night doomscrolling, neglecting your responsibilities and relationships.
In the harsh light of day, you are forced to confront the consequences of your actions. You have allowed social media to consume your life, and in doing so, you have lost sight of what truly matters.
{updateHappiness(-20)}
Overwhelmed by regret and self-loathing, you sink into a deep depression. The outside world becomes a distant memory as you retreat further into your digital prison. You have sacrificed your well-being for the fleeting dopamine rush that social media provides, and now you are paying the price.
{HideCharacter("PhoneScreen4")}
* [End Game]
{RestartGame()}
-> END

=== Part1 ===
~ setTitle("{name}'s Room, Friday")
{ShowBackground("MessyBedroom1")}
{ShowCharacter("PhoneScreen3", "mid")}
You begin to navigate through the labyrinth of settings until you find what you’re looking for: screen time limits
With a few taps, you set strict boundaries, vowing to reclaim control over your digital habits.
{HideCharacter("PhoneScreen3")}
You put your phone away, out of sight and out of mind. In its absence, you feel a sense of unease but also a feeling of a weight being lifted from your shoulders. 
How would you like to spend your time? 
* [Go work on a hobby] -> WorkOnHobby
* [Scroll through social media] -> ScrollSocialMedia


=== WorkOnHobby ===
{ShowCharacter("Guitar", "right")}
{PlaySFX("GuitarSFX")}
You decide to spend some time listening and playing some music, which you have not done in while. You dust off the old guitar that’s been sitting in the corner of your room for months. 
Lost in the creative process, you lose track of time and hours pass by in a blur as you experiment with different melodies, feeling a renewed sense of purpose. 
{updateHappiness(20)}
You realize that engaging in a hobby you are passionate about has not only provided a much-needed break from screens but has also allowed you to reconnect with a part of yourself you had neglected. You vow to make time for hobbies more often, recognizing the importance of fostering passions. 
{HideCharacter("Guitar")}
-> Part2A


=== ScrollSocialMedia ===
{ShowCharacter("PhoneScreen4", "mid")}
After putting your phone down, you feel uneasy and crave the familiarity of scrolling through social media. Ignoring the reminder of your screen time limits, you reach for your phone.
With each swipe and tap, you are feeling more and more detached from the world around you, losing yourself in the endless scroll of curated images and updates. The minutes turn into hours, your mind numbed by the overwhelming amount of information and content. 
{updateHappiness(-20)}
You realize with a sinking feel that you’ve undone all the progress you made in reclaiming control over your digital habits. As you finally set aside your phone and drift off to sleep, a sense of unease and anxiety lingers. Deep down, you know that true fulfillment lies not in the artificial validation of the digital world, but in the meaningful connections and experiences in the real world.
{HideCharacter("PhoneScreen4")}
-> Part2B

=== Part2A ===
~ setTitle("{name}'s Room, Saturday")
The next morning arrives and as you slowly open your eyes, you’re greeted by a sense of calmness in the air, a stark contrast to the usual grogginess that accompanies the start of a new day. 
As you stretch and rise from bed, feeling surprisingly well-rested and energized you glance at your phone which was left untouched from the previous day. Your phone begins to buzz with a familiar notification. You check the notification, seeing a message from the friend you made plans with a few days ago. 
{PlaySFX("PhonePing")}
“Hey {name}! Just wanted to check in and confirm our coffee date for today. Can’t wait to catch up with you!” 
-> RespondToCheckIn


=== Part2B ===
~ setTitle("{name}'s Room, Saturday")
The next morning arrives and as you slowly open your eyes, you’re greeted by a sense of heaviness in the air. Rubbing your eyes, you groggily reach for your phone.
Your phone begins to buzz with a familiar notification. You check the notification, seeing a message from the friend you made plans with a few days ago. 
{PlaySFX("PhonePing")}
“Hey {name}! Just wanted to check in and confirm our coffee date for today. Can’t wait to catch up with you!” 
-> RespondToCheckIn

=== RespondToCheckIn ===
How would you like to respond?
* "Hey Sam! I’m really looking forward to our coffee date, can’t wait to catch up with you too!" 
    -> YesToPlans
* "Sorry, something came up last minute. Maybe next time!"
    ->NoToPlans



=== YesToPlans ===
{updateHappiness(20)}
{PlaySFX("PhoneTexting")}
{ShowCharacter("PhoneScreen5A", "mid")}
You quickly type out a response, expressing your enthusiasm to see them. A smile spreads across your face as you are excited to reconnect with your old roommate, Sam. It’s been a while since you made plans with friends and despite constantly checking online forums, you have been feeling isolated and alone. 
As you get ready for the day ahead, you can’t help but notice the positive impact that engaging in your hobby and reconnecting with a friend has had on your mood and outlook. 
{HideCharacter("PhoneScreen5A")}
-> Plans


=== NoToPlans ===
{updateHappiness(-20)}
{PlaySFX("PhoneTexting")}
{ShowCharacter("PhoneScreen5B", "mid")}
As you stare at the message of your friend, a wave of conflicting emotions washes over you. While part of you misses human connection, another part feels weighed down by a sense of guilt and unease. 
You hesitantly respond that now is not the right time as you feel that you’re not in the right headspace to engage in social interaction. 
As you hit send, you can’t help but feel like you’ve let your friend down and missed out on an opportunity for connection. The weight of your decision hangs heavy on your shoulders. 
You still have time to decide, are you sure you want to say no? 
{HideCharacter("PhoneScreen5B")}
* Stick with your choice 
    -> NoPlans
* Text Sam you can make it for coffee  
    -> TextSam

=== NoPlans ===
{updateHappiness(-20)}
As the hours pass by, you can’t shake the feeling of loneliness that settles over you. Despite your best efforts to distract yourself with more technology, the nagging sense of guilt still lingers. 
You find yourself retreating to the solitude of your bed earlier than usual. 
With a heavy sigh, you slip beneath the covers, staring up at the ceiling in the dim light of your room. As the night stretches on and the darkness deepens, you find yourself trapped in a cycle of regret and sadness. 
-> BadEnding

=== TextSam ===
{updateHappiness(20)}
You find yourself regretting your decision as you long for connection. With a deep breath, you reach for your phone and begin to type out a message asking if it was still possible to meet for coffee. 
A sense of relief washes over you as your friend quickly responds with enthusiasm, eager to resume plans. 
-> Plans


=== Plans ===

As the time for your coffee date with Sam approaches, you find yourself feeling nervous. It’s been too long since you’ve made plans with a friend, the thought of stepping out of your comfort zone fills you with anxiety. 
~ setTitle("Outside")
{ShowBackground("Outdoors")}
{updateHappiness(20)}
With a deep breath, you push aside the doubts and worries, stepping outside into the crisp spring air. You’re greeted by the sight of blossoming flowers and the sweet melody of birds above you. The world seems to come alive around you as you embrace the present moment, marveling at the beauty of the world around you. 
As you approach the cafe, you can’t help but feel grateful for the simple act of stepping outside and walking towards a brighter, more fulfilling future. You take a moment to appreciate the warmth of the sun and beauty of nature surrounding you, you feel at peace and more alive than you have in a long time.
~ setTitle("Cafe")
{ShowBackground("Cafe")}
{updateHappiness(20)}
Arriving at the cafe, you spot your friend Sam waiting for you at a table on the outdoor terrace. As you sip your coffee and share stories of your lives, you’re reminded of the power of human connection and the importance of surrounding yourself with supportive friends. You decide to open up about your struggles with mental health and screen addiction with Sam.
To your surprise, Sam listens attentively, their expression one of empathy and compassion. As you speak, you feel a weight lifting from your shoulders and a sense of gratitude for the connection you share. This was a reminder of how true change is possible, especially when you have a supportive community to lean on. 
->GoodEnding

=== GoodEnding ===
{PlayBGM("ChillLofi")}
As the day comes to a close, you find yourself sitting quietly, reflecting on the events of the day. 
The coffee date with Sam served as a turning point—a reminder of the importance of human connection and the support of friends on your journey toward self-improvement. Though the road ahead may be long and challenging, you're filled with a renewed determination to continue making positive changes in your life.
{ShowBackground("CleanBedroom")}
~ setTitle("{name}'s Room, Sunday")
You take the time to clean your room, clearing away the clutter of gadgets and technology that had been weighing you down. In doing so, you made a conscious decision to go on a digital cleanse — a temporary break from technology to focus on healthier habits and self-care.
As you disconnect from the digital world, you rediscover the joys of living in the moment — whether it's taking a walk through nature, picking up a hobby, or enjoying the company of loved ones.
You realize the importance of taking time for yourself — to rest,  recharge, and reconnect with truly matters. As you commit to prioritizing your well-being and nurturing healthy habits, you feel a sense of purpose and fulfillment growing within you.
With a contented sigh, you close your eyes and drift off to sleep, filled with hope for the future and a deep sense of appreciation for the journey you're on. Tomorrow is a new day, and though there may still be obstacles to overcome, you face them with resilience, knowing that you're moving in the right direction.
* [End Game]
{RestartGame()}
->END


=== BadEnding ===
{PlayBGM("Desolate")}
The next day, you wake up with a heavy heart, still feeling the weight of your decision from the previous night. As you move through your morning routine, a sense of hopelessness settles over you. Throughout the day, you find yourself succumbing to comfort and retreating further into yourself. 
The days turn into weeks and weeks into months, you find yourself sinking deeper into unhealthy habits consumed by depression and loneliness.
In the end, you realize that by refusing to strive toward healthier habits and making a change, you’ve sealed your own fate, condemning yourself to a life of loneliness and despair. As you stare off, you can’t help but wonder what might have been if only you had the strength to step outside your comfort zone. But now, it’s too late. 
* [End Game]
{RestartGame()}
->END

=== function updateHappiness(amount) ===
    ~ happiness = happiness + amount
    
=== function setTitle(string)
    ~ title = string