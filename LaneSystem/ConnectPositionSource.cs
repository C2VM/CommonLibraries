using Unity.Entities;
using Unity.Mathematics;

namespace C2VM.CommonLibraries.LaneSystem;

public struct ConnectPositionSource : IBufferElementData
{
    public float3 m_Position;

    public int m_NodeLaneIndex;

    public ConnectPositionSource(float3 position, int nodeLaneIndex)
    {
        m_Position = position;
        m_NodeLaneIndex = nodeLaneIndex;
    }

    public bool Equals(ConnectPositionSource other)
    {
        return m_Position.Equals(other.m_Position);
    }

    public override int GetHashCode()
    {
        return m_Position.GetHashCode();
    }
}