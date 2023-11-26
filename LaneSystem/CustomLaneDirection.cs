using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

namespace C2VM.CommonLibraries.LaneSystem;

public struct CustomLaneDirection : IBufferElementData, IQueryTypeParameter, ISerializable
{

    public static Restriction LeftOnly = new Restriction{
        m_BanStraight = true,
        m_BanRight = true,
        m_BanUTurn = true
    };

    public static Restriction StraightOnly = new Restriction{
        m_BanLeft = true,
        m_BanRight = true,
        m_BanUTurn = true
    };

    public static Restriction RightOnly = new Restriction{
        m_BanLeft = true,
        m_BanStraight = true,
        m_BanUTurn = true
    };

    public static Restriction LeftAndStraight = new Restriction{
        m_BanRight = true,
        m_BanUTurn = true
    };

    public static Restriction RightAndStraight = new Restriction{
        m_BanLeft = true,
        m_BanUTurn = true
    };

    public static Restriction[][] DefaultConfig = new Restriction[9][]{
        new Restriction[0],
        new Restriction[1]{
            new Restriction{
                m_BanUTurn = true
            }
        },
        new Restriction[2]{
            LeftAndStraight,
            RightAndStraight
        },
        new Restriction[3]{
            LeftOnly,
            StraightOnly,
            RightOnly,
        },
        new Restriction[4]{
            LeftOnly,
            LeftAndStraight,
            RightAndStraight,
            RightOnly
        },
        new Restriction[5]{
            LeftOnly,
            StraightOnly,
            StraightOnly,
            StraightOnly,
            RightOnly
        },
        new Restriction[6]{
            LeftOnly,
            LeftOnly,
            StraightOnly,
            StraightOnly,
            RightOnly,
            RightOnly
        },
        new Restriction[7]{
            LeftOnly,
            LeftOnly,
            StraightOnly,
            StraightOnly,
            StraightOnly,
            RightOnly,
            RightOnly
        },
        new Restriction[8]{
            LeftOnly,
            LeftOnly,
            StraightOnly,
            StraightOnly,
            StraightOnly,
            StraightOnly,
            RightOnly,
            RightOnly
        }
    };

    public struct Restriction {
        public bool m_BanLeft;

        public bool m_BanRight;

        public bool m_BanStraight;

        public bool m_BanUTurn;
    }

    public float3 m_SourcePosition;

    public Restriction m_Restriction;

    public bool m_Initialised;

    public static Restriction DefaultRestriction(int laneCount, int laneIndex)
    {
        if (laneCount >= DefaultConfig.Length || laneIndex >= DefaultConfig[laneCount].Length)
        {
            return default(Restriction);
        }
        return DefaultConfig[laneCount][laneIndex];
    }

    public CustomLaneDirection(float3 sourcePosition)
    {
        m_SourcePosition = sourcePosition;
    }

    public CustomLaneDirection(float3 sourcePosition, Restriction restriction)
    {
        m_SourcePosition = sourcePosition;
        m_Restriction = restriction;
        m_Initialised = true;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
        writer.Write(m_SourcePosition);
        writer.Write(m_Restriction.m_BanLeft);
        writer.Write(m_Restriction.m_BanRight);
        writer.Write(m_Restriction.m_BanStraight);
        writer.Write(m_Restriction.m_BanUTurn);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
        reader.Read(out m_SourcePosition);
        reader.Read(out m_Restriction.m_BanLeft);
        reader.Read(out m_Restriction.m_BanRight);
        reader.Read(out m_Restriction.m_BanStraight);
        reader.Read(out m_Restriction.m_BanUTurn);
        m_Initialised = true;
    }
}