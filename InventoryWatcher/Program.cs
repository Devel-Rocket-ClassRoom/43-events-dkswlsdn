using System;

Inventory inventory = new Inventory();
InventoryUI inventoryUI = new InventoryUI();
AutoBuyer autoBuyer = new AutoBuyer();

inventory.ItemChanged += inventoryUI.PrintChangeLog;
inventory.ItemChanged += autoBuyer.AutoBuy;

inventory.AddItem("포션", 5);
inventory.AddItem("화살", 10);
inventory.AddItem("포션", 3);
inventory.RemoveItem("화살", 7);
inventory.RemoveItem("화살", 5);
