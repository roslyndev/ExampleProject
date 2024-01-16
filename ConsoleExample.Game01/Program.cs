using ConsoleExample.Game01.Abstracts;
using ConsoleExample.Game01.Entities;
using System;

namespace ConsoleExample.Game01
{
    internal class Program
    {
        static User player;

        static void Main(string[] args)
        {
            
            Init();
            player.Name = GetUserName();
            Hello(player.Name);
            Dungeon();
        }

        static void Init()
        {
            Console.WriteLine("=========================================================");
            Console.WriteLine(" 던전탐험에 오신 것을 환영합니다.");
            Console.WriteLine("=========================================================");
            Console.WriteLine("");
            Console.WriteLine("모험을 떠난 용사여, 그대가 도착한 이곳은 으슥하고 적막한 마을입니다.");
            Console.WriteLine("마을 사람들은 두려운 시선으로 당신을 바라보고 있습니다.");
            Console.WriteLine("그때 마을 이장이 다가와 당신에게 묻습니다.");
            Console.WriteLine("\"당신은 누구요?\"");

            player = new User();
        }

        static string GetUserName()
        {
            string name;
            do
            {
                Console.WriteLine("이제 당신의 이름을 알려주세요.");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("이름을 입력하세요.");
                }

            } while (string.IsNullOrWhiteSpace(name));

            return name;
        }

        static void Hello(string name)
        {
            Console.WriteLine($"\"어서오시오, {name}...\"");
            Console.WriteLine("\"하지만 당신은 잘못 왔소.  이곳은 죽음의 저주가 내려진 곳이오.  어서 떠나시오.\"");
            Console.WriteLine("이장의 말을 들은 당신은 놀란 표정이 되어 그들에게 왜 그런지 물었습니다.");
            Console.WriteLine("자초지정을 들어보니 마을에 괴물들이 나타나고 있었습니다.");
            Console.WriteLine("괴물들을 물리치기로 결심한 당신은 괴물들의 근거지를 물었고, 그곳은 멀지 않은 곳에 있는 동굴이었습니다."); 
            Console.WriteLine("이제 당신은 동굴로 향합니다.");
        }

        static void Guide()
        {
            Console.WriteLine("=========================================================");
            Console.WriteLine(" 공격명령은 다음과 같습니다.");
            Console.WriteLine(" 0:파이어볼(10%)   1:매직애로우(60%)   2:스턴공격(40%)  3:일반공격(100%)");
            Console.WriteLine("=========================================================");
        }

        static void Dungeon()
        {
            IMonsterAction monster = null;  //현재 상대할 몬스터입니다.
            Random random = new Random();   //랜덤함수를 선언합니다.
            for(int i = 0; i < 20; i++)     //총 20번을 반복 수행하기 위해 for문을 이용해 0에서 19까지 수행합니다.
            {
                if (i == 0)                 //현재 i 가 0, 즉 최초의 몹이라면
                {
                    Guide();                //Guide 함수를 호출하여 게임 방법을 알려줍니다.
                    monster = new Zombie(); //현재 상대할 몬스터에 좀비를 대입합니다.
                }
                else                        //현재 i가 0보다 크다면
                {
                    switch (random.Next(3)) //랜덤 난수를 생성합니다.
                    {
                        case 0:             //0 이라면 좀비가 대입됩니다.
                            monster = new Zombie();
                            break;
                        case 1:             //1 이라면 스켈레톤이 대입됩니다.
                            monster = new Skeleton();
                            break;
                        case 2:             //2 라면 미이라가 대입됩니다.
                            monster = new Mummy();
                            break;
                    }
                }

                Battle(monster);            //Battle 함수를 호출해 싸웁니다.
                if (player.IsDead)          //싸움이 끝난 뒤에 플레이어가 죽었다면
                {
                    Fail();                 //실패함수를 호출하고
                    break;                  //현재 반복문을 중단합니다.
                }
                else                        //플레이어가 살아있다면
                {
                    player.LevelUp();       //레벨업을 합니다.
                }
            }

            monster = new Vampire();        //모든 몹이 다 죽어서 반복문이 끝나면 상대할 몬스터에 보스인 뱀파이어를 대입합니다.
            Battle(monster);                //싸웁니다
            if (player.IsDead)              //플레이어가 죽었다면
            {
                Fail();                     //실패함수를 호출합니다.
            }
            else                            //플레이어가 살아있다면
            {
                Success();                  //성공함수를 호출합니다.
            }

            //던전함수가 종료되고 게임이 끝납니다.
        }

        static void Battle(IMonsterAction monster)
        {
            Console.WriteLine($"앗, 몬스터가 나타났다.  {monster.GetName()}!!");

            string attack = string.Empty;
            bool isProc = true;

            do
            {
                do
                {
                    Console.Write("공격방식을 선택하세요.");
                    attack = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(attack))
                    {
                        Console.Write("공격방식을 선택하세요.");
                    }

                } while (string.IsNullOrWhiteSpace(attack));

                Damage attackSkill = player.GetDamage(attack);
                monster.SetDamage(attackSkill);

                if (monster.IsStatus())
                {
                    isProc = false;
                }
                else
                {
                    Console.WriteLine("몬스터가 공격해온다!");
                    player.SetDamage(monster.GetDamage());
                    if (player.IsDead)
                    {
                        isProc = false;
                    }
                }

                if (isProc)
                {
                    Console.WriteLine("=========================================================");
                    Console.WriteLine($" 당신의 체력 : {player.Health}");
                    Console.WriteLine($" 몬스터의 체력 : {monster.GetHealth()}");
                    Console.WriteLine("=========================================================");
                }
            } while (isProc);

        }

        static void Fail()
        {
            Console.WriteLine("\"크읔... 내가 지다니...\"");
            Console.WriteLine("당신은 죽었습니다.");
            Console.WriteLine("게임이 종료됩니다.");
        }

        static void Success()
        {
            Console.WriteLine("성공입니다.  당신은 마을을 구했습니다.");
            Console.WriteLine("모두가 당신을 보며 기뻐하고 있습니다.  당신은 이제 이 마을의 영웅입니다.");
            Console.WriteLine("게임이 종료됩니다.");
        }
    }
}
