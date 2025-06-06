using System;
using System.IO;
using System.Threading.Tasks;

namespace AutoCamp.Helper
{
    public static class ChromeProfileHelper
    {
        public static async Task<string> CreateChromeProfile(string rootPath, string uid)
        {
            try
            {
                if (string.IsNullOrEmpty(rootPath))
                {
                    return "Đường dẫn root không hợp lệ";
                }

                if (string.IsNullOrEmpty(uid))
                {
                    return "UID không hợp lệ";
                }

                // Tạo đường dẫn profile với tên là uid
                string profilePath = Path.Combine(rootPath, uid);

                // Tạo thư mục profile nếu chưa tồn tại
                if (!Directory.Exists(profilePath))
                {
                    Directory.CreateDirectory(profilePath);
                }

                // Tạo các thư mục con cần thiết cho Chrome profile
                string[] subDirectories = new string[]
                {
                    "Default",
                    "Local Storage",
                    "Session Storage",
                    "Cache",
                    "Code Cache",
                    "GPUCache",
                    "Service Worker"
                };

                foreach (string dir in subDirectories)
                {
                    string fullPath = Path.Combine(profilePath, dir);
                    if (!Directory.Exists(fullPath))
                    {
                        Directory.CreateDirectory(fullPath);
                    }
                }

                // Tạo file Preferences với cấu hình cơ bản
                string preferencesPath = Path.Combine(profilePath, "Default", "Preferences");
                string defaultPreferences = @"{
                    ""profile"": {
                        ""default_content_setting_values"": {
                            ""notifications"": 2
                        },
                        ""password_manager_enabled"": false,
                        ""exit_type"": ""Normal"",
                        ""exited_cleanly"": true
                    },
                    ""browser"": {
                        ""enabled_labs_experiments"": [],
                        ""window_placement"": {
                            ""maximized"": true
                        }
                    }
                }";

                await File.WriteAllTextAsync(preferencesPath, defaultPreferences);

                return "Tạo profile Chrome thành công";
            }
            catch (Exception ex)
            {
                return $"Lỗi khi tạo profile Chrome: {ex.Message}";
            }
        }
    }
} 