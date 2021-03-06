//tabs=4
// --------------------------------------------------------------------------------
// TODO fill in this information for your driver, then remove this line!
//
// ASCOM Rotator driver for RotatorSimulator
//
// Description:	Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam 
//				nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam 
//				erat, sed diam voluptua. At vero eos et accusam et justo duo 
//				dolores et ea rebum. Stet clita kasd gubergren, no sea takimata 
//				sanctus est Lorem ipsum dolor sit amet.
//
// Implements:	ASCOM Rotator interface version: 1.0
// Author:		(XXX) Your N. Here <your@email.here>
//
// Edit Log:
//
// Date			Who	Vers	Description
// -----------	---	-----	-------------------------------------------------------
// dd-mmm-yyyy	XXX	1.0.0	Initial edit, from ASCOM Rotator Driver template
// --------------------------------------------------------------------------------
//
using System.Runtime.InteropServices;
using ASCOM.DeviceInterface;
using System.Collections;
using ASCOM;

namespace ASCOM.Simulator
{
    //
    // Your driver's ID is ASCOM.LoadSimulator.Rotator
    //
    // The Guid attribute sets the CLSID for ASCOM.LoadSimulator.Rotator
    // The ClassInterface/None addribute prevents an empty interface called
    // _Rotator from being created and used as the [default] interface
    //
    [Guid("2B6577C6-558A-484A-978B-1EA233A23849")]
    [ServedClassName("Rotator (Load Test) .NET")]
    [ProgId("ASCOM.LoadSimulator.Rotator")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)] 
	public class Rotator : ReferenceCountedObjectBase, IRotatorV2
	{
        /// <summary>
        /// Driver ID - ClassID and used in the profile
        /// </summary>
        private string driverID = "ASCOM.LoadSimulator.Rotator";

		//
		// Constructor - Must be public for COM registration!
		//
		public Rotator()
        {
            driverID = Marshal.GenerateProgIdForType(this.GetType());
            //System.Windows.Forms.MessageBox.Show("Test");       // allows time for attach to process
        }

		//
		// PUBLIC COM INTERFACE IRotator IMPLEMENTATION
        //
        #region IDeviceControl Members
        /// <summary>
        /// Invokes the specified device-specific action.
        /// </summary>
        /// <exception cref="MethodNotImplementedException"></exception>
        public string Action(string actionName, string actionParameters)
        {
            throw new ASCOM.ActionNotImplementedException(actionName);
        }

	    public void CommandBlind(string command, bool raw)
	    {
            throw new ASCOM.MethodNotImplementedException("CommandBlind " + command);
	    }

	    public bool CommandBool(string command, bool raw)
	    {
            throw new ASCOM.MethodNotImplementedException("CommandBool " + command);
	    }

	    public string CommandString(string command, bool raw)
	    {
            throw new ASCOM.MethodNotImplementedException("CommandString " + command);
	    }

	    public void Dispose()
	    {
            //throw new MethodNotImplementedException("Dispose");
	    }

        /// <summary>
        /// Gets the supported actions.
        /// </summary>
        public ArrayList SupportedActions
        {
            // no supported actions, return empty array
            get { ArrayList sa = new ArrayList(); return sa; }
        }

        #endregion
        
        #region IRotator Members
        public bool Connected
        {
            get { return RotatorHardware.Connected; }
            set { RotatorHardware.Connected = value; }
        }

        public string Description
        {
            get { return RotatorHardware.Description; }
        }

        public string DriverInfo
        {
            get { return RotatorHardware.DriverInfo; }
        }

        public string DriverVersion
        {
            get { return RotatorHardware.DriverVersion; }
        }

        public short InterfaceVersion
        {
            get { return RotatorHardware.InterfaceVersion; }
        }

        public string Name
        {
            get { return RotatorHardware.RotatorName; }
        }

	    public bool CanReverse
		{
			get { return RotatorHardware.CanReverse; }
		}

	    public void Halt()
		{
			RotatorHardware.Halt();
		}

		public bool IsMoving
		{
			get { return RotatorHardware.Moving; }
		}

		public void Move(float position)
		{
			RotatorHardware.Move(position);
		}

		public void MoveAbsolute(float position)
		{
			RotatorHardware.MoveAbsolute(position);
		}

		public float Position
		{
			get { return RotatorHardware.Position; }
		}

		public bool Reverse
		{
			get { return RotatorHardware.Reverse; }
			set { RotatorHardware.Reverse = value; }
		}

		public void SetupDialog()
		{
			if(RotatorHardware.Connected)
				throw new DriverException("The rotator is connected, cannot do SetupDialog()",
									unchecked(ErrorCodes.DriverBase + 4));
            RotatorHardware.SetupDialog();

			//RotatorSimulator.m_MainForm.DoSetupDialog();			// Kinda sleazy
		}

	    public float StepSize
		{
			get { return RotatorHardware.StepSize; }
		}

		public float TargetPosition
		{
			get { return RotatorHardware.TargetPosition; }
		}

		#endregion
	}
}
