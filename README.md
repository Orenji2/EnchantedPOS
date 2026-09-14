**EnchantedPOS 🛒**
A robust, multi-terminal Point of Sale (POS) and Inventory Management system built with C# (Windows Forms) and MySQL. Designed specifically for fast-paced grocery and retail environments, EnchantedPOS ensures quick checkouts, strict cashier accountability, and accurate inventory tracking.

**🚀 Major Update:** EnchantedPOS has officially migrated its database backend from MS Access to MySQL! This upgrade enables true multi-terminal networking, faster transaction processing, and enhanced data security across the local network.

**✨ Key Features**
💻 Point of Sale (Checkout)
Fast-Paced Scanning: Seamless barcode scanning with automatic parsing for scale/weighed items (e.g., meats and produce).

Suspend & Recall (F10 / F11): Instantly park an active cart with a custom name/note to keep the line moving, and recall it when the customer is ready.

Crash Recovery: Transactions are logged to a TEMP_REGISTER in real-time. If the PC loses power, the exact cart is recovered automatically upon reboot.

Dynamic Pricing Tiers: Easily toggle between Regular, Wholesale, VIP, and Royal pricing with manager override support.

📊 Shift & Cash Management
X-Readings (F12): Generate end-of-shift reports tracking total transactions, starting change funds, and expected cash-in-drawer.

Tax Compliance: Automated BIR-ready VAT breakdown calculation on printed receipts (VATable, 12% VAT, VAT Exempt, and Zero-Rated sales).

Hardware Integration: Built-in receipt printer routing and preview dialogs.

**📦 Back-Office & File Maintenance**
Multi-Terminal Support: Centralized MySQL database with dynamic connection strings via App.config for Host and Remote terminals.

**Inventory Master:** Comprehensive product tracking with bi-directional markup/margin calculations.

**Entity Management:** Built-in CRUD modules for Cashiers (Role-Based Access), Suppliers, and Customers (Ready for Sales on Account).

**🛠️ Tech Stack**
Frontend: C# / .NET Windows Forms (WinForms)

**Database:** MySQL Server 8.0+

**Configuration:** XML-based App.config for dynamic network routing

**🚀 Installation & Setup**
1. Database Configuration
Install MySQL Server and MySQL Workbench.

Create a new schema named EnchantedPOS.

Execute the provided SQL migration scripts (located in /Database) to build the Master, Register, Suspend, and User tables.

If setting up a multi-terminal network, ensure your host machine's firewall allows inbound TCP traffic on port 3306, and update your MySQL my.ini to bind-address = 0.0.0.0.

2. Application Setup
Clone this repository to your local machine.

Open the solution in Visual Studio.

Open the App.config file and update the connection string to point to your MySQL instance:

XML
<connectionStrings>
  <add name="DefaultConnection" 
       connectionString="Server=localhost;Database=EnchantedPOS;Uid=root;Pwd=YourPassword;" 
       providerName="MySql.Data.MySqlClient" />
</connectionStrings>
(Note: For remote terminals, change Server=localhost to the host computer's static IPv4 address, e.g., Server=192.168.100.151)

Build and Run!

⌨️ Keyboard Shortcuts
F1: Return focus to Barcode Scanner

F2: Initiate Payment

F3: Edit/Void Transaction (Manager Override required)

F10: Suspend Cart (Park Transaction)

F11: Recall Suspended Cart

F12: End Shift / Print X-Reading

ESC: Select Discount Type

DEL: Remove Selected Item

/ (Divide): Edit Item Quantity
