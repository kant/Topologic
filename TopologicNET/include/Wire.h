#pragma once

#include <Topology.h>

#include <TopologicCore/include/Wire.h>

namespace Topologic {
	ref class Vertex;
	ref class Edge;
	ref class Face;

	/// <summary>
	/// A Wire is a contiguous collection of Edges, where adjacent Edges are connected by shared Vertices. It may be open or closed and may be manifold or non-manifold. 
	/// </summary>

	public ref class Wire : Topology
	{
	public:
		/// <summary>
		/// Creates a Wire by a set of Edges.
		/// </summary>
		/// <param name="edges">The set of Edges</param>
		/// <exception cref="ArgumentException">Thrown if any of the arguments is not a Topologic Edge</exception>
		/// <returns name="Wire">The created Wire</returns>
		static Wire^ ByEdges(System::Collections::Generic::IEnumerable<Edge^>^ edges);

		/// <summary>
		/// Returns the Edges constituent to the Wire. NOTE: This method will automatically identify its loop order property.
		/// </summary>
		/// <returns name="Edge[]">A list of Edges constituent to the Wire</returns>
		property List<Edge^>^ Edges
		{
			List<Edge^>^ get();
		}

		/// <summary>
		/// Returns the Faces containing the Wire.
		/// </summary>
		/// <returns name="Face[]">A list of Faces containing the Wire</returns>
		property List<Face^>^ Faces
		{
			List<Face^>^ get();
		}

		/// <summary>
		/// Returns the Vertices constituent to the Wire. NOTE: This method will automatically identify its loop order property.
		/// </summary>
		/// <returns name="Vertex[]">A list of Vertices constituent to the Wire</returns>
		property List<Vertex^>^ Vertices
		{
			List<Vertex^>^ get();
		}

		/// <summary>
		/// Returns the number of branches of the Wire.
		/// </summary>
		/// <returns></returns>
#ifdef TOPOLOGIC_DYNAMO
		[IsVisibleInDynamoLibrary(false)]
#endif
		int GetNumberOfBranches();

		/// <summary>
		/// Checks if the Wire is closed.
		/// </summary>
		/// <returns name="bool">True if the Wire is closed, otherwise false</returns>
		property bool IsClosed
		{
			bool get();
		}

		/// <summary>
		/// Creates a geometry from Wire.
		/// </summary>
		/// <returns>The created geometry</returns>
		property Object^ BasicGeometry
		{
			virtual Object^ get() override;
		}

		/// <summary>
		/// Returns the type associated to Wire.
		/// </summary>
		/// <returns>The type associated to Wire</returns>
		static int Type();

	public protected:
		Wire();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="kpCoreWire"></param>
		Wire(const std::shared_ptr<TopologicCore::Wire>& kpCoreWire);

#ifdef TOPOLOGIC_DYNAMO
		/// <summary>
		/// Create a wire by a polycurve (including a polygon).
		/// </summary>
		/// <param name="polyCurve">The polycurve</param>
		/// <returns name="Wire">The created Topologic wire</returns>
		static Wire^ ByPolyCurve(Autodesk::DesignScript::Geometry::PolyCurve^ polyCurve);
#endif

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		virtual std::shared_ptr<TopologicCore::TopologicalQuery> GetCoreTopologicalQuery() override;

	protected:
		virtual ~Wire();

		/// <summary>
		/// 
		/// </summary>
		std::shared_ptr<TopologicCore::Wire>* m_pCoreWire;
	};
}