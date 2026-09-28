using System;
using System.Collections.Generic;

namespace HeartstringsBlazor
{
    #region 1. ADAPTER PATTERN
    public interface IFriendshipMomentScanner
    {
        string LogMemoryMoment();
    }

    public class HandwrittenDiaryNote
    {
        public string ReadPencilEntry(int yearWritten)
        {
            return $"Diary page from {yearWritten}: 'We promised to stay best friends forever over cinnamon cocoa.'";
        }
    }

    public class DiaryMemoryAdapter : IFriendshipMomentScanner
    {
        private readonly HandwrittenDiaryNote _diaryNote;

        public DiaryMemoryAdapter(HandwrittenDiaryNote diaryNote)
        {
            _diaryNote = diaryNote;
        }

        public string LogMemoryMoment()
        {
            string rawDiary = _diaryNote.ReadPencilEntry(2021);
            return $"[Memory Adapter Active] {rawDiary} -> Converted to Digital Memory Reel: Eternal Bond Milestone Unlocked!";
        }
    }
    #endregion

    #region 2. BRIDGE PATTERN
    public interface IBondVibe
    {
        string ExpressVibe();
    }

    public class GentleComfortVibe : IBondVibe
    {
        public string ExpressVibe() => "with soft reassurance, deep listening, and a soothing whisper";
    }

    public class PlayfulEnergyVibe : IBondVibe
    {
        public string ExpressVibe() => "with sparkling giggles, shared inside jokes, and joyful laughter";
    }

    public abstract class FriendlyGesture
    {
        protected IBondVibe Vibe;

        protected FriendlyGesture(IBondVibe vibe)
        {
            Vibe = vibe;
        }

        public abstract string ShareInteraction();
    }

    public class WarmHugGesture : FriendlyGesture
    {
        public WarmHugGesture(IBondVibe vibe) : base(vibe) { }

        public override string ShareInteraction() =>
            $"Shared a Cozy Bear Hug {Vibe.ExpressVibe()}!";
    }

    public class SincereComplimentGesture : FriendlyGesture
    {
        public SincereComplimentGesture(IBondVibe vibe) : base(vibe) { }

        public override string ShareInteraction() =>
            $"Gifted a Heartfelt Compliment {Vibe.ExpressVibe()}!";
    }
    #endregion

    #region 3. COMPOSITE PATTERN
    public interface ISocialUnit
    {
        string DisplayFriendTree(int depth);
        int CalculateTotalBondPoints();
    }

    public class CloseFriend : ISocialUnit
    {
        public string FriendName { get; }
        public int BondScore { get; }

        public CloseFriend(string name, int bondScore)
        {
            FriendName = name;
            BondScore = bondScore;
        }

        public string DisplayFriendTree(int depth) =>
            new string(' ', depth * 4) + $"* [Friend: {FriendName}] (Bond Affinity: +{BondScore} pts)\n";

        public int CalculateTotalBondPoints() => BondScore;
    }

    public class FriendshipCircle : ISocialUnit
    {
        public string CircleName { get; }
        private readonly List<ISocialUnit> _members = new List<ISocialUnit>();

        public FriendshipCircle(string circleName)
        {
            CircleName = circleName;
        }

        public void AddMember(ISocialUnit unit) => _members.Add(unit);

        public string DisplayFriendTree(int depth)
        {
            string tree = new string(' ', depth * 4) + $"[Circle: {CircleName}]\n";
            foreach (var member in _members)
            {
                tree += member.DisplayFriendTree(depth + 1);
            }
            return tree;
        }

        public int CalculateTotalBondPoints()
        {
            int total = 0;
            foreach (var member in _members) total += member.CalculateTotalBondPoints();
            return total;
        }
    }
    #endregion

    #region 4. DECORATOR PATTERN
    public interface IFriendshipCard
    {
        string GetCardDescription();
        int GetHeartAffinity();
    }

    public class BaseAffectionCard : IFriendshipCard
    {
        public string GetCardDescription() => "Pastel 'Thinking of You' Postcard";
        public int GetHeartAffinity() => 50;
    }

    public abstract class KeepsakeDecorator : IFriendshipCard
    {
        protected IFriendshipCard InnerCard;

        protected KeepsakeDecorator(IFriendshipCard card)
        {
            InnerCard = card;
        }

        public virtual string GetCardDescription() => InnerCard.GetCardDescription();
        public virtual int GetHeartAffinity() => InnerCard.GetHeartAffinity();
    }

    public class HandmadeBraceletKeepsake : KeepsakeDecorator
    {
        public HandmadeBraceletKeepsake(IFriendshipCard card) : base(card) { }

        public override string GetCardDescription() => InnerCard.GetCardDescription() + " + Beaded Friendship Bracelet";
        public override int GetHeartAffinity() => InnerCard.GetHeartAffinity() + 45;
    }

    public class MemoryLocketKeepsake : KeepsakeDecorator
    {
        public MemoryLocketKeepsake(IFriendshipCard card) : base(card) { }

        public override string GetCardDescription() => InnerCard.GetCardDescription() + " + Golden Heart Photo Locket";
        public override int GetHeartAffinity() => InnerCard.GetHeartAffinity() + 60;
    }
    #endregion

    #region 5. FACADE PATTERN
    public class CozyFairyLighting
    {
        public string DimToGoldenGlow() => "Strung warm fairy lights and lit lavender aromatherapy candles.";
    }

    public class AcousticMusicPlaylist
    {
        public string PlayLofiMelodies() => "Streaming soft acoustic indie guitar & ambient fireplace audio.";
    }

    public class SweetSnackTreats
    {
        public string ServeChaiAndPastries() => "Baked strawberry macarons and brewed cinnamon chai tea.";
    }

    public class SlumberPartyGatheringFacade
    {
        private readonly CozyFairyLighting _lights = new CozyFairyLighting();
        private readonly AcousticMusicPlaylist _music = new AcousticMusicPlaylist();
        private readonly SweetSnackTreats _treats = new SweetSnackTreats();

        public List<string> HostFriendshipSlumberParty()
        {
            return new List<string>
            {
                "[Gathering Step 1] " + _lights.DimToGoldenGlow(),
                "[Gathering Step 2] " + _music.PlayLofiMelodies(),
                "[Gathering Step 3] " + _treats.ServeChaiAndPastries(),
                "[Celebration Active] Blankets spread out! Besties sharing bedtime stories and group hugs!"
            };
        }
    }
    #endregion

    #region 6. FLYWEIGHT PATTERN
    public class HeartParticleType
    {
        public string TintColor { get; }
        public string SpriteSheet { get; }
        public string ShaderEffect { get; }

        public HeartParticleType(string color, string sprite, string shader)
        {
            TintColor = color;
            SpriteSheet = sprite;
            ShaderEffect = shader;
        }

        public string Render(int x, int y, double floatSpeed) =>
            $"Rendered '{TintColor}' heart [{SpriteSheet}] at ({x}, {y}) [Rise Speed: {floatSpeed:F1}x] via {ShaderEffect}.";
    }

    public class HeartParticleFactory
    {
        private static readonly Dictionary<string, HeartParticleType> _cache = new Dictionary<string, HeartParticleType>();

        public static HeartParticleType GetHeartType(string color, string sprite, string shader)
        {
            if (!_cache.ContainsKey(color))
            {
                _cache[color] = new HeartParticleType(color, sprite, shader);
            }
            return _cache[color];
        }

        public static int CachedParticleProfilesCount => _cache.Count;
    }

    public class ActiveHeartParticle
    {
        private readonly int _x;
        private readonly int _y;
        private readonly double _speed;
        private readonly HeartParticleType _sharedType;

        public ActiveHeartParticle(int x, int y, double speed, HeartParticleType type)
        {
            _x = x;
            _y = y;
            _speed = speed;
            _sharedType = type;
        }

        public string Draw() => _sharedType.Render(_x, _y, _speed);
    }
    #endregion

    #region 7. PROXY PATTERN
    public interface ISecretSanctuary
    {
        string EnterSanctuary();
    }

    public class RealBestiesSanctuary : ISecretSanctuary
    {
        public string SanctuaryName { get; }

        public RealBestiesSanctuary(string name)
        {
            SanctuaryName = name;
        }

        public string EnterSanctuary() =>
            $"[Sanctuary Unlocked]: Welcomed into '{SanctuaryName}' treehouse lounge with the private digital scrapbook!";
    }

    public class BestiesSanctuaryProxy : ISecretSanctuary
    {
        private RealBestiesSanctuary? _realSanctuary;
        private readonly string _sanctuaryName;
        private readonly int _bondAffinityPoints;

        public BestiesSanctuaryProxy(string name, int bondPoints)
        {
            _sanctuaryName = name;
            _bondAffinityPoints = bondPoints;
        }

        public string EnterSanctuary()
        {
            if (_bondAffinityPoints < 500)
            {
                return $"[ACCESS RESTRICTED] Follower Bond Affinity ({_bondAffinityPoints}/1000 pts) too low! 500+ bond points required for Inner Circle Secret Sanctuary access.";
            }

            if (_realSanctuary == null)
            {
                _realSanctuary = new RealBestiesSanctuary(_sanctuaryName);
                return "[BFF Tier Verified - Lazy Loading Memory Album] " + _realSanctuary.EnterSanctuary();
            }

            return "[Instant Access] " + _realSanctuary.EnterSanctuary();
        }
    }
    #endregion
}