// FontManager.cs (수정된 버전)
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace library_support_system // (사용자님의 네임스페이스)
{
    public static class FontManager
    {
        private static PrivateFontCollection privateFonts = new PrivateFontCollection();
        private static FontFamily customFontFamily;

        // 1. 로드할 폰트 파일명 목록 (Fonts 폴더 기준)
        private static readonly string[] fontFiles = {
            "Paperlogy-1Thin.ttf",
            "Paperlogy-2ExtraLight.ttf",
            "Paperlogy-3Light.ttf",
            "Paperlogy-4Regular.ttf",
            "Paperlogy-5Medium.ttf",
            "Paperlogy-6SemiBold.ttf",
            "Paperlogy-7Bold.ttf",
            "Paperlogy-8ExtraBold.ttf",
            "Paperlogy-9Black.ttf"
        };

        public static void LoadFonts()
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string assemblyNamespace = assembly.GetName().Name; // "library_support_system"

                foreach (string fontFile in fontFiles)
                {
                    // 2. 하이픈(-)을 언더스코어(_)로 변환한 리소스 이름 생성
                    string resourceFileName = fontFile.Replace('-', '_');
                    string resourceName = $"{assemblyNamespace}.Fonts.{resourceFileName}";

                    using (Stream fontStream = assembly.GetManifestResourceStream(resourceName))
                    {
                        if (fontStream == null)
                        {
                            // 3. (실패 시 원본 하이픈 이름으로 다시 시도 - 혹시 모를 경우 대비)
                            resourceName = $"{assemblyNamespace}.Fonts.{fontFile}";
                            using (Stream retryStream = assembly.GetManifestResourceStream(resourceName))
                            {
                                if (retryStream == null)
                                {
                                    MessageBox.Show($"오류: 폰트 리소스를 찾을 수 없습니다.\n파일: {fontFile}\n경로: {resourceName}");
                                    continue; // 다음 폰트 시도
                                }
                                AddFontFromStream(retryStream);
                            }
                        }
                        else
                        {
                            AddFontFromStream(fontStream);
                        }
                    }
                }

                if (privateFonts.Families.Length > 0)
                {
                    // 4. "Paperlogy"라는 이름의 Font Family가 로드됨
                    customFontFamily = privateFonts.Families[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("폰트 로드 실패: " + ex.Message);
            }
        }

        // 폰트 스트림을 메모리에 추가하는 헬퍼 메서드
        private static void AddFontFromStream(Stream fontStream)
        {
            byte[] fontdata = new byte[fontStream.Length];
            fontStream.Read(fontdata, 0, (int)fontStream.Length);

            IntPtr data = Marshal.AllocCoTaskMem(fontdata.Length);
            Marshal.Copy(fontdata, 0, data, fontdata.Length);

            privateFonts.AddMemoryFont(data, fontdata.Length);

            Marshal.FreeCoTaskMem(data);
        }

        // 5. GetFont 메서드 (기존과 동일)
        public static Font GetFont(float size, FontStyle style = FontStyle.Regular)
        {
            if (customFontFamily == null)
            {
                LoadFonts();
            }

            if (customFontFamily != null)
            {
                // 9개 폰트가 "Paperlogy"라는 하나의 Family로 묶였으므로
                // style (Bold, Regular 등)을 지정하면
                // Windows가 알아서 적절한 폰트 파일(예: Paperlogy-7Bold)을 사용합니다.
                return new Font(customFontFamily, size, style);
            }
            else
            {
                return new Font("맑은 고딕", size, style);
            }
        }
    }
}