using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace LrOOPn1
{

	interface ISay
	{
		void Say(int i);
	}

	interface ILocation
	{
		string Locate {get;set;}
	}

	class RandName
	{
		static string[] ManNames = { "Ник", "Пйеро", "Дартаньян", "Зед", "Тед", "Локи", "Мэни", "Бен"};
		static string[] WomanNames = { "Фиона", "Лея", "Дария", "Гвен", "Астрид", "Локи", "Мэни", "Бен" };
		static string[] AnimalNames = { "Аксель", "Арнульв", "Аудульв", "Бёдольв", "Гринольв", "Ингольв", "Йорген", "Калле" };
		static string[] LizardNames = { "Смауг", "Смертнокрыл", "Малигос", "Изериус", "Нефириан", "Алекстрас"};
		static string[] FishNames = { "Ариэль", "Аделль", "Андрина", "Аквата"};

		public static string giveRandName(string who)
		{
			Random rand = new Random();
			switch (who)
			{
				case "man":
				case "male":
					{ 
						return ManNames[rand.Next(0, ManNames.Length-1)]; 
					}
					break;
				case "woman":
				case "female":
					{
						return WomanNames[rand.Next(0, WomanNames.Length - 1)];
					}
					break;
				case "animal":
					{
						return AnimalNames[rand.Next(0, AnimalNames.Length - 1)];
					}
					break;
				case "dragon":
					{
						return LizardNames[rand.Next(0, LizardNames.Length - 1)];
					}
					break;
				case "fish":
					{
						return FishNames[rand.Next(0, FishNames.Length - 1)];
					}
					break;
				default:
					return "??????";
					break;
			}


		}
		public RandName()
		{
			
		}
	}

	abstract class Entity : ISay
	{
		public string Who { get; set; }
		public string Name { get; set; }
		public int Power { get; set; }

		public Entity(string w,string n, int p) {
			Who = w;
			Name = n;
			Power = p;
		}
		public abstract void HowAmI();

		public abstract void Say(int i);
		
	}
	class Hero : Entity
	{
		public bool HeroLife { get; set; }
		public Hero(string name, int power) : base("Герой", name, power)
		{
			HeroLife = true;
		}

		public override void Say(int i)
		{
			HowAmI();
		}

		public void ReSay(object sender, string who, int level)
		{
			switch (who)
			{
				case "Принцесса":
					{
						Princess princess = (Princess)sender;
						HowAmI();
						MyText.AddText($"Дополнивши, Герой сказал : \"Теперь идём домой {princess.Name}\", - после чего поцелавал её.\n");
					}
					break;
				case "Сильный воин":
					{
						StrongMan enemy = (StrongMan)sender;
						switch (level)
						{
							case 0:
								{
									MyText.AddText($"- Герой запомнил эти слова, и решил представится: \"Меня зовут {base.Name}. Скажи мне тоже свое имя.\"");
								}
								break;
							case 1:
								{
									MyText.AddText($"\"А ты, {enemy.Name}, отлично сражаеся, для своих лет\", - сказал Герой, отскочивши в сторону.");
								}
								break;
							case 2:
								{
									if (Power >= enemy.Power) MyText.AddText($"\"Победишь! — крикнул Герой, — Я! тот единственый, кто спасет принцессу, не ты. Можешь продолжать лежать в луже собственой крови\".\n");
									else { MyText.AddText($"\"А ты и вправду достоен спасти принцессу\", — еле сказал Герой и упал на землю.\n"); HeroLife = false; }
								}
								break;
						}
					}
					break;
				case "Волк":
					{
						Wolf enemy = (Wolf)sender;
						switch (level)
						{
							case 0:
								{
									MyText.AddText($"- Герой, не растирявшись, тоже бросился на опасного зверя.");
								}
								break;
							case 1:
								{
									MyText.AddText($"Но все же, {base.Name} смог провести отличную конторатаку. Уже предвкушая победу, представился."); HowAmI();
								}
								break;
							case 2:
								{
									if (Power >= enemy.Power)
									{
										MyText.AddText($"{base.Name} успел быстро отреагировать, поэтому рана была не глубокой, ударивши в грудь твари. Он скалал : \"Может представишся, чтоб те кто пели про мои подвиги, знали имя грозного зверя против которого я сражался \"\n");
										enemy.HowAmI(); MyText.AddText($"После чего загадочний зверь с именем {enemy.Name} был убит.\n");
									}
									else { MyText.AddText($"\"Не надо было раслабляться, не закончив сражение\", — попытался проговорить Герой, но уже не мог, поскольку его горло было настолько повреджено, что реки крови стекали ему на обувь. Из-за потери достаточного количества жидкости у Героя потемнела в глазах. И он рухнул на поляну, уже украшеною красным цветом и освещенную луным светом.\n"); HeroLife = false; }
								}
								break;
						}
					}
					break;
				case "Русалка":
					{
						Mermaid enemy = (Mermaid)sender;
						switch (level)
						{
							case 0:
								{
									MyText.AddText($"- Герой с радостью решил представиться: \"Меня зовут {base.Name}. И я иду спасать принцессу\".");
									MyText.AddText($"\"{enemy.Name}, скажи как попасть на ту сторону реки\", - сказал {base.Name}.\n");
								}
								break;
							case 1:
								{
									MyText.AddText($"\"Хорошо\" - ответил {base.Who}.");
									MyText.AddText($"После чего {enemy.Name} начала свою песню, про любовь и т.д. подобное");
									MyText.AddText($"Разум {base.Name} потихоньку затуманивался, и он начал понемногу заходить в воду.\n");
								}
								break;
							case 2:
								{
									MyText.AddText($"От чего Герой уже не контролировал своё тело, был полностью в любовных чарах пленительницы.");
									if (Power >= enemy.Power) { MyText.AddText($"Но в последний миг, у него промелькнула еле уловимая мисль: " +
										$"\"Я отпраился в это опасное, не для того чтоб заниматься любовью с {enemy.Who.Substring(0, enemy.Who.Length - 1)}ой, а чтобы спасти Принцессу\".");
										MyText.AddText($"Прийдя в здравый разум, он понял что из него высасывают жизненую силу, через 5 секунд {enemy.Name} была придушена его голыми руками. {base.Name} поплыл на тот берег через реку.\n");
									}
									else { MyText.AddText($"{base.Who} полностью отключился. И его сердце остановилось.\n"); HeroLife = false; }
								}
								break;
						}
					}
					break;
				case "Черный рыцарь":
					{
						BlackKnight enemy = (BlackKnight)sender;
						switch (level)
						{
							case 0:
								{
									HowAmI();
									MyText.AddText($"\"А ты видимо владелец места сего, - проговорил Герой. Нуждающий в помощи, {base.Name} сказал - Я очень устал с дороги, могу я остаться здесь на ночь?\"\n");
								}
								break;
							case 1:
								{
									MyText.AddText($"{base.Who} понял что схватки не избежать, и тоже начал готовиться.");
									MyText.AddText($"\"Перед, началом боя может ты тоже представишся?\", - сказал {base.Name}");
								}
								break;
							case 2:
								{
									MyText.AddText($"Они долго сражались, и схватка эта была не на жизнь, а на смерть. Но в итоге: ");
									if (Power-50 >= enemy.Power)
									{
										MyText.AddText($"проткнувши мечом противника, {base.Who} понял что победил.\n");
										MyText.AddText($"Оставивши мертвое тело на полу, {base.Name} пошел спать.\n");
										MyText.AddText($"На следующее утро {enemy.Who} сказал, по какой дороге лучше идти и что при следующей встречи он не будет так подаватся.\n");
									}
									else { MyText.AddText($"{base.Name} остался без головы, которая в свою же очередь будет украшать вход перед замком\n"); HeroLife = false; }
								}
								break;
						}
					}
					break;
				case "Дракон":
					{
						Dragon enemy = (Dragon)sender;
						switch (level)
						{
							case 0:
								{
									MyText.AddText($"\"Я не стану тебе называться ты чертова ящерица и не буду танцевать по твоей прихоти!\" - дерзко ответил герой.\n");
								}
								break;
							case 1:
								{
									MyText.AddText($"{base.Name} долго уворачивался от атак дракона. Но долго это не могло продолжаться, и дракон загнал его в угол." +
										$" У героя не осталась не доспехов, не щита, ни меча, только его обломок, все расплавилось от огня, что выдыхал {enemy.Name}.\n");
								}
								break;
							case 2:
								{
									MyText.AddText($"\"Я истинный рыцарь, я никогда не сдамся, пока мои ноги держат меня на земле, а руки мои могут сражаться, моя воля к победе будет безграничная, и кровь что бурлит в моих венах пронзит небеса.\""); 
									MyText.AddText($"После чего Древний {enemy.Who} надул живот, и выпустил струю огня прямо в Героя.\n");
									if (Power >= 200)
									{
										MyText.AddText($"Не растерявшись, {base.Name} проскользил под пламенем, и скрылся в камнях");
										MyText.AddText($"Не заметив этого {enemy.Name}, нагнулся к луже магмы, что образавалась от камня и его огня, что бы увидеть останки Героя.");
										MyText.AddText($"В этот же момент, Герой выскочил из-за скалы, что была рядом, и проткнул одно из самых незащищенных мест Дракона"); 
										MyText.AddText($"Осколок меча в руках героя, что торчал из глаза Древнего Змея, начал светиться, и яркая вспышка пробила череп Дракону, то ли это была помощь Богов, то ли сама Воля Героя, но факт остаеться фактом что Герой смог одолеть страшное чудовище, что тераризировала их королевсто не одно тисячилетие.");
										MyText.AddText($"И {base.Name} закричал что есть мощь: \"Я зделал это, я спас принцессу, я убил зло этого мира, Да-а-а-а-а!\". После чего поспешил в башню к принцессе.\n");
									}
									else {
										MyText.AddText($"{base.Name} замедлился на секунду, из-за величия Древнего Змея и того, что он оказался в такой затруднительной ситауции. Это стоило ему жизни.");
										MyText.AddText($"На камне что стоял позади Героя отпечатался его силует, а само его тело слилось в одно единое с землей.\n");
										HeroLife = false; 
									}
								}
								break;
						}
					}
					break;
			}
		}
		public override void HowAmI()
		{
			MyText.AddText($"\"Я {base.Who}, и зовуся {base.Name}. Сила моя {base.Power} ед.\", - С увереностью в голосе говорит Он.\n");
		}
	}
	class Princess : Entity
	{
		public bool saved { get; set; }
		public Princess(string name, int power) : base("Принцесса", name, power)
		{
			saved = false;
		}

		public override void Say(int i)
		{
			HowAmI();
			MyText.AddText($"\"Я так рада что ты пришел меня спасти, - побежала в слезах, радости, {base.Who} чтобы обнять спасителя. Обнявши, спросила, - Скажешь своё имя?\"");
			Meet?.Invoke(this, base.Who, i);
		}
		public override void HowAmI()
		{
			MyText.AddText($"\"Меня зовут {base.Name}. Я первая и последня {base.Who} IХ Короля, что правит королевством \"Великого Соцна\"\", - представилась Леди прекрасного пола.");
		}

		public event EventMeet Meet;

	}

	public delegate void EventMeet(object sender, string who, int levelDialoga);
	public delegate void EventEniv(string locate);
	abstract class Enemy : Entity
	{
		public Enemy(string w, string n, int p):base(w,n,p)
		{
		}

		public virtual event EventMeet Meet;
		public virtual event EventEniv Environment;
    }
	
	class StrongMan : Enemy, ILocation
	{
		public string Locate { get; set; }
		public StrongMan(string name, int power) : base("Сильный воин", name, power)
		{
			Locate = "Королевский Турнир";
		}


        public override void Say(int i)
		{
			switch (i)
			{
				case 0:
					{
						Environment?.Invoke(Locate);
						MyText.AddText($"- Воин против которого стоял наш герой, сказал: \"Ну здраству мой противник. Ты будешь легко повержен. Моя могучая сила тебе не по зубам\"");
					}
					break;
				case 1:
					{
						HowAmI();
						MyText.AddText($"\"Но врядле тебе это поможет\", - сказал Он и продолжал наступать.");
						MyText.AddText($"\nПрошло порядка десяти или уже двенадцати минут боя. Как звуки мечей перекрыл голос.\n");
					}
					break;
				case 2:
					{
						MyText.AddText($"- на что Воин только усмехнулся.\n");
					}
					break;
				case 3:
					{
						MyText.AddText($"\"Я ж сказал, это \"Также легко, как 2 пальца обос*ть\", - наклонившись к Герою молвил {base.Name}. А после крикнул, - Принцесса моя! Никто не смеет и тронуть её пальцем, всем головы посворачиваю.\n");
					}
					break;
			}
			Meet?.Invoke(this, base.Who, i);
		}

        public override void HowAmI()
        {
			MyText.AddText($"\"Меня зовут {base.Name}. Люди говорят, моя сила {base.Power} ед.\", - представился Воин");
		}

		public override event EventMeet Meet;
		public override event EventEniv Environment;
		
	}
    class Wolf : Enemy, ILocation
    {
        public string Locate { get; set; }
        public Wolf(string name, int power) : base("Волк", name, power)
        {
			Locate = "Лес";
		}
		public override void Say(int i)
		{
			switch (i)
			{
				case 0:
					{
						Environment?.Invoke(Locate);
						MyText.AddText($"- Это был {base.Who}, показавши зубы, прогавкал: \"Куда идешь путник, я думаю это твоя конечная.\". После чего набросился на Героя");
					}
					break;
				case 1:
					{
						MyText.AddText($"{base.Who} аткавал без перерыва, то когтями пытался поцарапать, то зубами укусить.\n");
					}
					break;
				case 2:
					{
						MyText.AddText($"Воспользывавши, отвлеченостью Героя. Зверь вцепился в шею противника.");
					}
					break;
				case 3:
					{
						MyText.AddText($"\"Поздравляю Герой, ты пополнил ряди тех, кто стал моим обедом\", - подумал про себя {base.Who}, и начал трапезничать.\n");
					}
					break;
			}
			Meet?.Invoke(this, base.Who, i);
		}

		public override void HowAmI()
		{
			MyText.AddText($"\"Меня зовут {base.Name}. Люди говорят, моя сила {base.Power} ед.\", - рявкнул Волк");
		}

		public override event EventMeet Meet;
		public override event EventEniv Environment;

	}
    class Mermaid : Enemy, ILocation
    {
		public string Locate { get; set; }
		public Mermaid(string name, int power) : base("Русалка", name, power)
        {
			Locate = "Река";
		}
		public override void Say(int i)
		{
			switch (i)
			{
				case 0:
					{
						Environment?.Invoke(Locate);
						MyText.AddText($"На камне в реке сидела {base.Who}.");
						HowAmI();
						MyText.AddText($"\"Назовешься и ты статный красавец?\" - сказала {base.Name}. И погладив свои волоссы посмотрела на человека.");
					}
					break;
				case 1:
					{
						MyText.AddText($"\"Знаю\" - ответила Она. \"Но после того как послушаешь мою песню, Хорошо?\" - миленько похихикала {base.Who}.");
					}
					break;
				case 2:
					{
						MyText.AddText($"{base.Who} своим сладким ангельским голосоком подзывала героя, все ближе и ближе, к себе, пока тот уже не стоял, по пупок в воде, в 5 меторов от её камня.");
						MyText.AddText($"После чего Она нырнула в реку, и в миг очутившись возле Героя, обхаватила его шею и страстно поцеловала в губы.");
					}
					break;
				case 3:
					{
						MyText.AddText($"\"Но знаешь, ты был лучший из всех, кого я встречала за последние 200 лет\", - прошептала {base.Who} на ухо уже бездыханому телу, что постепено начало погружаться в воду.\n");
						MyText.AddText($"\"Все же вы мужики одинаковые, никто из вас не устоял перед моим телом и голосом\", - облизавши пальцы {base.Name} отправилась обатно на камень, в то время тело Героя лежало на дне реки и стало кормом для обитателей, этих вод.\n");
					}
					break;
			}
			Meet?.Invoke(this, base.Who, i);
		}
		public override void HowAmI()
		{
			MyText.AddText($"\"Меня зовут {base.Name}. Я хранительница реки и моя сила {base.Power} ед.\", - пропела Русалка");
		}

		public override event EventMeet Meet;
		public override event EventEniv Environment;

	}
    class BlackKnight : Enemy, ILocation
    {
        
		public string Locate { get; set; }
		public BlackKnight(string name, int power) : base("Черный рыцарь", name, power)
		{
			Locate = "Темный замок";
		}
		public override void Say(int i)
		{
			switch (i)
			{
				case 0:
					{
						Environment?.Invoke(Locate);
						MyText.AddText($"\"Ты кто такой?! Шатаешся здесь, Убирайся прочь!\" - крикнул Хозяин замка. Он был полностью облочен в черные доспехи и шлем, через который даже лица его не было видно.");
					}
					break;
				case 1:
					{
						MyText.AddText($"\n\"Для непрошеных гостей тут только одно условия, победи и на ночь дворец твой\", - ответил хозяин, и начал достовать меч из ножен.\n");
					}
					break;
				case 2:
					{
						HowAmI();
						MyText.AddText($"И поединок начался... Герой мог только отбиватся, поскольку уже был на предели своих возможностей.\n");
					}
					break;
				case 3:
					{
						MyText.AddText($"\"Не понимаю, что все суда лезут\", - сказал {base.Who} своему ворону, что сел ему на плечё\n");
					}
					break;
			}
			Meet?.Invoke(this, base.Who, i);
		}
		public override void HowAmI()
		{
			MyText.AddText($"\"Меня зовут {base.Name}. Но тебе всеровно этого не понять, такчто узнай мою силу в бою\", - со зларадствующим смехом произнес Темный Рыцарь.");
		}

		public override event EventMeet Meet;
		public override event EventEniv Environment;

	}
    class Dragon : Enemy, ILocation
    {
        public Dragon(string name, int power) : base("Дракон", name, power)
        {
			Locate = "Башня";
		}
		public string Locate { get; set; }
		public override void Say(int i)
		{
			switch (i)
			{
				case 0:
					{
						Environment?.Invoke(Locate);

						MyText.AddText($"Дракон спустился вниз, с вершины башни, где у него было гнездо с его трофеями, и предстал во всей своей красе перед героем.");
						HowAmI();
						MyText.AddText($"Дракон не сйел героя сразу, а он мог сделать это, поскольку заскучал по мере долгой своей жизни.");
						MyText.AddText($"\"Ну назовись хоть бы, и позабавь меня своей зубочисткой\", - почесавши свой живот, сказал {base.Name}");
					}
					break;
				case 1:
					{
						MyText.AddText($"\"Да как ты посмел, блоха, которую я прихлопну, одной левой, такое сказать\", - прорычал дракон, что аж дым из его ноздрей повалил. И тот начал нападать.");
					}
					break;
				case 2:
					{
						MyText.AddText($"\"Можешь сказать свои последние слова ничтожество\", - высокомерно прогремел Дракон.");
					}
					break;
				case 3:
					{
						MyText.AddText($"Поняв что все кончено, {base.Name} взмахнул крыльями, взлетел обратно к себе в гнездо.");
						MyText.AddText($"После чего, засунул голову в спальню к Принцессе и с ухмилкой молвил: \"Самый сильный герой этого столетия, оставил свою жизнь возле того камня в низу, так что ты осталась тут до конца своих лет, ну если конечно не доживешь до 100 лет. А-хахахах-а-а-а-а\".\n");
					}
					break;
			}
			Meet?.Invoke(this, base.Who, i);
		}
		public override void HowAmI()
		{
			MyText.AddText($"\"Я Грозный и Могучий {base.Name}. Тебе в одиночку никогда не победить меня, моя сила превосходит сотню королевских воинов с силой 50 ед., что я сйел при прошлом короле\", - гремящим возгласом, на пару мил, проревел Древий Дракон.");
		}

		public override event EventMeet Meet;
		public override event EventEniv Environment;

	}
    class MyText
	{
		static string text { get; set; }

		static public void AddText(string s)
		{
			text += s;
			text += '\n';
		}

		static public void ShowConsole()
		{
			Console.WriteLine(text);
		}

		static public void SaveInFile(string path)
		{
			DirectoryInfo dirInfo = new DirectoryInfo(path);
			if (!dirInfo.Exists)
			{
				dirInfo.Create();
			}

			using (FileStream fstream = new FileStream(@$"{path}\Tale.txt", FileMode.OpenOrCreate))
			{
				byte[] array = System.Text.Encoding.Default.GetBytes(text);
			
				fstream.Write(array, 0, array.Length);
				Console.WriteLine("Текст записан в файл, по пути " + @$"{path}\Tale.txt");
			}
		}
	}

	class Journey
	{

		Hero hero { get; set; }
		Princess princess { get; set; }
		List<Enemy> enemies { get; set; }

		public int Days { get; set; }
		public Journey()
		{

			Random rand = new Random();


			Days = 1;

			enemies = new List<Enemy>();
			
			hero = new Hero(RandName.giveRandName("man"), rand.Next(0, 220));
			princess = new Princess(RandName.giveRandName("woman"), 0);

			enemies.Add(new StrongMan(RandName.giveRandName("man"), rand.Next(10, 50)));
			enemies.Add(new Wolf(RandName.giveRandName("animal"), rand.Next(20, 70)));
			enemies.Add(new Mermaid(RandName.giveRandName("fish"), rand.Next(30, 60)));
			enemies.Add(new BlackKnight(RandName.giveRandName(""), rand.Next(40, 100)));
			enemies.Add(new Dragon(RandName.giveRandName("dragon"), rand.Next(7000, 12000)));
		}

		public void WhereHero(string locate) {

			switch (locate)
			{
				case "Королевский Турнир":
					{
						MyText.AddText($"Попавши на {locate}, {hero.Name} с легостью добрался до участия в финале.\n");
					}
					break;
				case "Лес":
					{
						MyText.AddText($"Зайдя в {locate}, что окружал королевство \"Великого Соцна\". Герой наткнулся на страное существо.\n");
					}
					break;
				case "Река":
					{
						MyText.AddText($"{locate} \"Прорубающая Небеса\" самая изветная во всем свете, выйдя к её берегу. {hero.Name} увидел в реке чтото интересное.\n");
					}
					break;
				case "Темный замок":
					{
						MyText.AddText($"От уже долгой дороги Герой решил остановиться на отдых в месте которого не было на карте. Это был {locate} готического стиля. С множеством комнат и коридоров. И когда {hero.Name} подумал, что \"все можно и пойти поспать\", его невзапно встретил хозяин замка\n");
					}
					break;
				case "Башня":
					{
						MyText.AddText($"И вот прибыл {hero.Name} к концу своего путешествия. Башня, что стояла посреди соженной, от сильного огня, пусташи, где были только скалы да камни. И осталось у него последняя преграда между ним и его красавицей это древний Дракон\n");
					}
					break;

			}

		}
		public void startJourney() {

			Random rand = new Random();

			hero.Say(0); MyText.AddText($"На {Days} день.\n"); MyText.AddText($"Отправился вызволять принцессу.\n");


			foreach (Enemy enemy in enemies)
			{
				enemy.Environment += WhereHero;
				enemy.Meet += hero.ReSay;

				Days += rand.Next(5, 24);
				MyText.AddText($"На {Days} день путишествия.\n");

				for (int i = 0; i < 4; i++)
				{ 
					if (hero.HeroLife && i==3) { continue; }
					enemy.Say(i);
				}
				if (!hero.HeroLife) { break; }
			}

			if (hero.HeroLife) { princess.Meet += hero.ReSay; princess.Say(0); MyText.AddText($"После чего они жили долго и очень счатливо."+(char)3+(char)3+(char)3); }
			else { MyText.AddText($"Вот такой печальный конец нашего Героя.\n"); }

		}

        public IEnumerable<Entity> SortedByPower(int power)
        {
            var query =
                from enemy in enemies
				where enemy.Power > power
                orderby enemy
				select enemy;
            return query;
        }

    }

	class Program
	{
		static void Main(string[] args)
		{
			Journey journey = new Journey();
			journey.startJourney();
			MyText.ShowConsole();

			string s;
			Console.WriteLine("Enter only path for save tale: ");
			s = Console.ReadLine();
			MyText.SaveInFile(s);
			MyText.SaveInFile("C:/tales/");
			
		}

	}

}