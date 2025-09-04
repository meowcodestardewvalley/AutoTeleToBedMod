using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using Microsoft.Xna.Framework;

namespace AutoTeleToBeoMod
{
    public class ModEntry : Mod
    {
        private bool wasExhaustedLastUpdate = false;

        public override void Entry(IModHelper helper)
        {
            // Đăng ký sự kiện update
            helper.Events.GameLoop.UpdateTicked += this.OnUpdateTicked;
            
            // Ghi log khởi động
            this.Monitor.Log("AutoTeleToBeoMod đã được khởi động!", LogLevel.Info);
        }

        private void OnUpdateTicked(object sender, UpdateTickedEventArgs e)
        {
            // Chỉ kiểm tra mỗi nửa giây để tối ưu hiệu năng
            if (!e.IsMultipleOf(30)) 
                return;

            //
