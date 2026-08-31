EnchantedPOS 🛒✨

A robust, fast-paced Point of Sale (POS) system built with C# and Windows Forms. Designed for high-volume retail environments and 24-hour continuous store operations, EnchantedPOS focuses on reliability, rapid checkout workflows, and seamless crash recovery.

Key Features
Real-Time Crash Recovery: Utilizes a TEMP_REGISTER database to save transactions per item scan. If a terminal loses power or reboots, the active transaction and its invoice number are automatically restored upon the cashier's next login.

Multi-Station Architecture: Supports multiple checkout counters simultaneously without cross-talk by binding transactions to specific local station numbers.

Dual-Language Product Search: Features a dynamic search interface allowing cashiers to look up items seamlessly using either English or Korean product names (ENG_NAME / KOR_NAME), perfect for international or specialty grocery inventories.

Smart Pricing Tiers: Built-in toggle modes (Regular, Wholesale, VIP, Royal) that automatically adjust the SRP of scanned items on the fly.

Rapid Keyboard Navigation: Optimized for mouse-free checkout lines using hotkeys (Enter to scan/search, ESC for discounts, '/' for quantity adjustments, and F3 for edits/voids).

Manager Overrides: Secure, password-protected intercept screens for sensitive actions like voiding entire transactions or manually overriding computed discounts.

Shift & Fund Tracking: Captures the active cashier ID, current shift number, and starting change funds right at login for accurate end-of-day auditing.

Tech Stack
Frontend: C# / .NET Windows Forms (WinForms)

Database: Microsoft Access (.accdb) using ADO.NET (OleDbConnection)

Architecture: Local client database integration with dynamic query generation and parameter binding.

Setup Instructions
Clone this repository to your local machine.

Ensure you have the Microsoft Access Database Engine (OLEDB 12.0) installed on your system.

Open the .sln file in Visual Studio.

Verify the database (dbEn.accdb) is placed in the root directory relative to the compiled executable (typically three folders up from the bin/Debug output).

Build and run the solution.
