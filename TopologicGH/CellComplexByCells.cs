﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace TopologicGH
{
    public class CellComplexByCells : GH_Component
    {

        public CellComplexByCells()
          : base("CellComplex.ByCells", "CellComplex.ByCells", "Creates a CellComplex by a set of Cells.", "Topologic", "CellComplex")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Cells", "Cells", "Cells", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("CellComplex", "CellComplex", "CellComplex", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Declare a variable for the input String
            List<Topologic.Cell> cells = new List<Topologic.Cell>();

            // Use the DA object to retrieve the data inside the first input parameter.
            // If the retieval fails (for example if there is no data) we need to abort.
            if (!DA.GetDataList(0, cells)) { return; }

            // If the retrieved data is Nothing, we need to abort.
            // We're also going to abort on a zero-length String.
            if (cells == null) { return; }
            //if (endVertex == null) { return; }
            //if (data.Length == 0) { return; }

            // Convert the String to a character array.
            //char[] chars = data.ToCharArray();

            
            Topologic.CellComplex cellComplex = Topologic.CellComplex.ByCells(cells);

            // Use the DA object to assign a new String to the first output parameter.
            DA.SetData(0, cellComplex);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return Resources.NMT_borderless_logo_small;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("08fce0bf-67ea-4844-8138-2ee3f3a2d97c"); }
        }
    }
}
