using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

namespace C2VM.CommonLibraries.LaneSystem;

public struct CustomLaneDirection : IBufferElementData, IQueryTypeParameter, ISerializable
{
    public struct Restriction {
        public bool m_BanLeft;

        public bool m_BanRight;

        public bool m_BanStraight;

        public bool m_BanUTurn;
    }

    public float3 m_SourcePosition;

    public Restriction m_Restriction;

    public bool m_Initialised;

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