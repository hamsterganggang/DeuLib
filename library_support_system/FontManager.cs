// FontManager.cs (최종 디버깅 - Font 생성 결과 확인)
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace library_support_system // ★★★ 사용자님 프로젝트 네임스페이스 확인 ★★★
{
    public static class FontManager
    {
        // --- Private Fields ---
        // 폰트 데이터를 메모리에 로드하기 위한 컬렉션
        private static PrivateFontCollection privateFonts = new PrivateFontCollection();
        // 로드된 FontFamily 객체들을 직접 저장하는 리스트 (이름 검색 및 Font 객체 생성용)
        private static List<FontFamily> loadedFontFamilies = new List<FontFamily>();
        // 폰트 로드 시도 여부 플래그 (중복 로드 방지)
        private static bool HasLoaded = false;

        // --- Configuration ---
        // ★★★ Fonts 폴더에 포함된 폰트 파일 이름 목록 ★★★
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
            // 다른 폰트 파일이 있다면 여기에 추가
        };

        // --- Public Methods ---

        /// <summary>
        /// 프로그램 시작 시 호출하여 포함된 폰트 리소스를 메모리에 로드합니다.
        /// 이미 로드된 경우 다시 실행되지 않습니다.
        /// </summary>
        public static void LoadFonts()
        {
            // 이미 로드 시도했으면 다시 안 함
            if (HasLoaded)
            {
                // Console.WriteLine("FontManager: LoadFonts() 이미 호출됨. 건너<0xEB><0x9B><0x84>니다."); // 필요시 주석 해제
                return;
            }
            HasLoaded = true; // 로드 시도 플래그 설정

            Console.WriteLine("FontManager: 폰트 로드를 시작합니다...");

            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string assemblyNamespace = assembly.GetName().Name;
                int loadedCount = 0; // 로드 성공 카운트

                // --- 1. 실제 포함된 리소스 이름 전부 출력 (디버깅용) ---
                string[] allResourceNames = assembly.GetManifestResourceNames();
                Console.WriteLine("==================================================");
                Console.WriteLine("실제 포함된 리소스 목록:");
                if (allResourceNames.Length == 0)
                {
                    Console.WriteLine(">> 포함된 리소스가 전혀 없습니다! 빌드 설정을 확인하세요!");
                }
                else
                {
                    // 폰트 파일 리소스만 필터링해서 보여주기 (선택적)
                    var fontResourceNames = allResourceNames.Where(name => name.EndsWith(".ttf", StringComparison.OrdinalIgnoreCase));
                    if (fontResourceNames.Any())
                    {
                        foreach (string name in fontResourceNames) { Console.WriteLine($"- {name}"); }
                    }
                    else
                    {
                        Console.WriteLine(">> .ttf 폰트 리소스를 찾을 수 없습니다! 빌드 작업 설정을 확인하세요.");
                    }
                }
                Console.WriteLine("==================================================");
                // --- 1. 끝 ---

                foreach (string fontFile in fontFiles)
                {
                    // Console.WriteLine($"\n--- 폰트 파일 처리 시작: {fontFile} ---"); // 필요시 주석 해제
                    string resourceFileName = fontFile.Replace('-', '_'); // 리소스 이름 규칙 (하이픈 -> 언더스코어)
                    string resourceNameWithUnderscore = $"{assemblyNamespace}.Fonts.{resourceFileName}";
                    string resourceNameWithHyphen = $"{assemblyNamespace}.Fonts.{fontFile}"; // 원래 파일 이름
                    Stream fontStream = null;

                    // --- 2. 리소스 찾기 시도 ---
                    // Console.WriteLine($"리소스 찾기 시도 1 (언더스코어): {resourceNameWithUnderscore}"); // 필요시 주석 해제
                    fontStream = assembly.GetManifestResourceStream(resourceNameWithUnderscore);

                    if (fontStream == null)
                    {
                        // Console.WriteLine(">> 실패. 리소스 찾기 시도 2 (하이픈): " + resourceNameWithHyphen); // 필요시 주석 해제
                        fontStream = assembly.GetManifestResourceStream(resourceNameWithHyphen);

                        if (fontStream == null)
                        {
                            Console.WriteLine($">> 경고: 리소스 '{fontFile}'를 찾을 수 없습니다! 건너<0xEB><0x9B><0x84>니다.");
                            // Console.WriteLine("--- 폰트 파일 처리 끝 ---"); // 필요시 주석 해제
                            continue; // 다음 파일로 넘어감
                        }
                        else
                        {
                            // Console.WriteLine(">> 하이픈 이름으로 리소스 찾기 성공!"); // 필요시 주석 해제
                        }
                    }
                    else
                    {
                        // Console.WriteLine(">> 언더스코어 이름으로 리소스 찾기 성공!"); // 필요시 주석 해제
                    }
                    // --- 2. 끝 ---


                    // --- 3. 폰트 메모리 로드 시도 ---
                    using (fontStream) // using으로 스트림 자동 닫기
                    {
                        // Console.WriteLine("AddFontFromStream 호출 시도..."); // 필요시 주석 해제
                        try
                        {
                            AddFontFromStream(fontStream);
                            // Console.WriteLine(">> AddFontFromStream 성공!"); // 필요시 주석 해제
                            loadedCount++;
                        }
                        catch (Exception addEx)
                        {
                            Console.WriteLine($">> AddFontFromStream 실패! ({fontFile}): {addEx.Message}");
                        }
                    }
                    // Console.WriteLine("--- 폰트 파일 처리 끝 ---"); // 필요시 주석 해제
                    // --- 3. 끝 ---
                } // end foreach

                // --- 4. 최종 로드 결과 확인 및 저장 ---
                loadedFontFamilies.Clear(); // 이전 데이터 제거
                // PrivateFontCollection에 실제로 로드된 FontFamily 객체들을 가져옴
                loadedFontFamilies.AddRange(privateFonts.Families);

                Console.WriteLine("\n==================================================");
                Console.WriteLine($"FontManager LoadFonts 완료. 총 {loadedCount}개 파일 처리 시도.");
                if (loadedFontFamilies.Count > 0)
                {
                    string loadedNames = string.Join("\n", loadedFontFamilies.Select(f => $"- '{f.Name}'"));
                    Console.WriteLine($"PrivateFontCollection에 최종 로드된 패밀리 ({loadedFontFamilies.Count}개):\n{loadedNames}");
                }
                else
                {
                    Console.WriteLine(">> PrivateFontCollection에 로드된 패밀리가 없습니다! 포함 리소스 설정 및 경로를 확인하세요.");
                }
                Console.WriteLine("==================================================");
                // --- 4. 끝 ---

            }
            catch (Exception ex)
            {
                // 전체 로드 과정에서 예외 발생 시
                Console.WriteLine("LoadFonts 전체 로직 중 심각한 오류 발생: " + ex.Message);
            }
        }

        /// <summary>
        /// 요청된 스타일(FontStyle)에 가장 적합한 로드된 폰트 패밀리를 찾아 Font 객체를 생성하여 반환합니다.
        /// 적합한 폰트를 찾지 못하면 시스템 기본 폰트(맑은 고딕)를 반환합니다.
        /// </summary>
        /// <param name="size">원하는 폰트 크기</param>
        /// <param name="style">원하는 폰트 스타일 (Bold, Regular 등)</param>
        public static Font GetFont(float size, FontStyle style = FontStyle.Regular)
        {
            // 폰트가 로드되지 않았으면 로드 시도 (최초 호출 시)
            if (loadedFontFamilies.Count == 0 && !HasLoaded)
            {
                Console.WriteLine("GetFont: 폰트가 로드되지 않아 LoadFonts()를 호출합니다.");
                LoadFonts();
            }
            // 로드 후에도 없으면 안전하게 기본 폰트 반환
            if (loadedFontFamilies.Count == 0)
            {
                Console.WriteLine("GetFont 오류: 폰트 로드 실패. 기본 폰트로 대체.");
                return new Font("Malgun Gothic", size, style);
            }

            Font createdFont = null; // 생성될 폰트 객체
            string targetFamilyName = null; // 찾은 패밀리 이름
            FontFamily foundFamily = null; // 찾은 패밀리 객체

            try
            {
                // 1. 요청된 스타일에 가장 적합한 실제 폰트 패밀리 이름 찾기
                targetFamilyName = FindBestMatchingFamilyName(style);

                // 2. 찾은 이름으로 실제 FontFamily 객체 찾기
                if (targetFamilyName != null)
                {
                    foundFamily = loadedFontFamilies.Find(f => f.Name.Equals(targetFamilyName, StringComparison.OrdinalIgnoreCase));
                }

                // 3. FontFamily 객체를 찾았으면 Font 객체 생성 시도
                if (foundFamily != null)
                {
                    Console.WriteLine($"GetFont: '{foundFamily.Name}' 패밀리로 Font(Size:{size}, Style:{style}) 생성 시도...");
                    createdFont = new Font(foundFamily, size, style);

                    // --- 4. 생성된 Font 객체 이름 확인 (GDI+ Fallback 체크) ---
                    if (createdFont != null) // 생성 성공 여부 확인
                    {
                        bool isMemoryFont = privateFonts.Families.Any(f => f.Name == createdFont.FontFamily.Name); // 메모리 폰트인지 확인
                        Console.WriteLine($">> 생성 결과: Name='{createdFont.Name}', Size={createdFont.SizeInPoints}pt, Style={createdFont.Style}, IsMemoryFont={isMemoryFont}");

                        // ★★★ 이름이 같고, 메모리 폰트가 맞는지 확인 ★★★
                        if (isMemoryFont && createdFont.Name.Equals(foundFamily.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            // Console.WriteLine(">> 메모리 폰트 객체 생성 성공!"); // 성공 로그는 주석 처리
                            return createdFont; // 성공! 반환
                        }
                        else
                        {
                            Console.WriteLine($"★★★★★ Fallback 발생 추정! ★★★★★");
                            Console.WriteLine($"기대한 이름: '{foundFamily.Name}', 실제 생성된 Font 이름: '{createdFont.Name}', 메모리 폰트 여부: {isMemoryFont}. 기본 폰트로 대체.");
                            createdFont?.Dispose(); // 실패한 객체 해제
                            return new Font("Malgun Gothic", size, style); // Fallback 시 기본 폰트
                        }
                    }
                    else
                    {
                        Console.WriteLine("★★★★★ Font 객체 생성 자체가 null 반환! ★★★★★");
                        return new Font("Malgun Gothic", size, style);
                    }
                    // --- 4. 끝 ---
                }
                else
                {
                    // 패밀리 객체를 못 찾음 (FindBestMatchingFamilyName 실패)
                    Console.WriteLine($"GetFont 경고: 요청 스타일({style})에 맞는 패밀리('{targetFamilyName ?? "null"}') 객체를 찾지 못함. 기본 폰트로 대체.");
                    return new Font("Malgun Gothic", size, style);
                }
            }
            catch (ArgumentException argEx) // FontFamily가 해당 스타일을 지원하지 않을 때 발생 가능
            {
                Console.WriteLine($"Font 객체 생성 중 인수 오류 (Size:{size}, Style:{style}, Family:'{foundFamily?.Name ?? "null"}'): {argEx.Message}. Regular로 재시도...");
                // 스타일 없이 Regular로 다시 시도
                try
                {
                    if (foundFamily != null) return new Font(foundFamily, size, FontStyle.Regular);
                }
                catch { /* 재시도 실패 시 아래 기본 폰트 반환 */ }
                return new Font("Malgun Gothic", size, style);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Font 객체 생성 중 오류 (Size:{size}, Style:{style}): {ex.Message}");
                createdFont?.Dispose(); // 예외 발생 시 생성된 객체 해제
                return new Font("Malgun Gothic", size, style); // 안전하게 기본 폰트 반환
            }
        }

        /// <summary>
        /// 지정된 폼과 모든 자식 컨트롤에 대해,
        /// 디자이너의 폰트 크기/스타일을 유지하면서 메모리 폰트로 강제 교체를 시도합니다.
        /// </summary>
        /// <param name="formToApply">폰트를 적용할 폼</param>
        public static void ForceApplyFontToAllControls(Form formToApply)
        {
            // 폰트 로드 확인
            if (loadedFontFamilies.Count == 0 && !HasLoaded) LoadFonts();
            if (loadedFontFamilies.Count == 0)
            {
                Console.WriteLine("ForceApplyFontToAllControls 오류: 로드된 폰트가 없어 적용할 수 없습니다.");
                return;
            }

            Console.WriteLine($"\n--- 폼 '{formToApply.Name}'에 폰트 강제 적용 시작 ---");
            try
            {
                // 1. 자식 컨트롤들 먼저 재귀적으로 교체 시도
                ForceApplyFontRecursively(formToApply.Controls);

                // 2. 폼 자체의 폰트도 교체 시도
                Font originalFormFont = formToApply.Font; // 디자이너 또는 기본값 폰트
                if (originalFormFont != null)
                {
                    // Console.WriteLine($"폼 '{formToApply.Name}' 자체 폰트 교체 시도: '{originalFormFont.Name}' ({originalFormFont.Size}pt, {originalFormFont.Style})"); // 필요시 주석 해제
                    // 현재 Size와 Style을 사용하여 GetFont 호출
                    Font newFormFont = GetFont(originalFormFont.Size, originalFormFont.Style);
                    // 교체 성공 여부 확인 (메모리 폰트인지)
                    if (newFormFont != null && loadedFontFamilies.Any(f => f.Name.Equals(newFormFont.Name, StringComparison.OrdinalIgnoreCase)))
                    {
                        if (formToApply.Font != newFormFont) formToApply.Font = newFormFont; else newFormFont.Dispose();
                        // Console.WriteLine($">> 폼 폰트 교체 결과: '{formToApply.Font.Name}'"); // 필요시 주석 해제
                    }
                    else
                    {
                        Console.WriteLine($">> 폼 폰트 교체 실패: GetFont가 '{newFormFont?.Name ?? "null"}' 반환.");
                        newFormFont?.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"폼 '{formToApply.Name}'에 폰트 강제 적용 중 오류: {ex.Message}");
            }
            Console.WriteLine($"--- 폼 '{formToApply.Name}' 폰트 강제 적용 완료 ---");
        }


        // --- Private Helper Methods ---

        /// <summary>
        /// 폰트 스트림 데이터를 메모리에 로드합니다. (내부 사용)
        /// </summary>
        private static void AddFontFromStream(Stream fontStream)
        {
            if (fontStream == null || fontStream.Length == 0)
            {
                Console.WriteLine("AddFontFromStream 오류: 유효하지 않은 스트림입니다.");
                return;
            }

            byte[] fontdata = new byte[fontStream.Length];
            int bytesRead = fontStream.Read(fontdata, 0, (int)fontStream.Length);
            if (bytesRead <= 0)
            { // 읽은 데이터 없으면 중단
                Console.WriteLine($"AddFontFromStream 경고: 스트림에서 데이터를 읽지 못했습니다 ({bytesRead} bytes).");
                return;
            }
            // 읽은 만큼만 메모리 할당 및 복사 (메모리 절약 및 오류 방지)
            IntPtr data = Marshal.AllocCoTaskMem(bytesRead);
            if (data == IntPtr.Zero)
            {
                Console.WriteLine("AddFontFromStream 오류: 메모리 할당 실패.");
                return;
            }
            try
            {
                Marshal.Copy(fontdata, 0, data, bytesRead);
                privateFonts.AddMemoryFont(data, bytesRead); // 여기가 핵심 로드 부분
            }
            catch (Exception ex)
            {
                // GDI+ 관련 오류일 수 있음 (예: 파일 형식이 잘못됨)
                Console.WriteLine($"AddMemoryFont 중 오류 발생: {ex.Message}");
            }
            finally
            {
                Marshal.FreeCoTaskMem(data); // 메모리 누수 방지
            }
        }

        /// <summary>
        /// 요청된 FontStyle에 가장 적합한 로드된 폰트 패밀리 이름을 반환합니다. (내부 사용)
        /// (이름 규칙: '페이퍼로지 N 이름', 예: '페이퍼로지 7 Bold')
        /// </summary>
        private static string FindBestMatchingFamilyName(FontStyle style)
        {
            // Bold 계열 우선 검색 (Bold > Black > ExtraBold > SemiBold)
            if ((style & FontStyle.Bold) == FontStyle.Bold)
            {
                var boldFamily = loadedFontFamilies.FirstOrDefault(f => f.Name.EndsWith(" 7 Bold", StringComparison.OrdinalIgnoreCase)) ??
                                 loadedFontFamilies.FirstOrDefault(f => f.Name.EndsWith(" 9 Black", StringComparison.OrdinalIgnoreCase)) ??
                                 loadedFontFamilies.FirstOrDefault(f => f.Name.EndsWith(" 8 ExtraBold", StringComparison.OrdinalIgnoreCase)) ??
                                 loadedFontFamilies.FirstOrDefault(f => f.Name.EndsWith(" 6 SemiBold", StringComparison.OrdinalIgnoreCase));
                if (boldFamily != null) return boldFamily.Name;
                // Fallback: Bold 계열 못 찾으면 Regular 계열 탐색
            }

            // Regular 계열 검색 (Regular > Medium > Light > ExtraLight > Thin)
            var regularFamily = loadedFontFamilies.FirstOrDefault(f => f.Name.EndsWith(" 4 Regular", StringComparison.OrdinalIgnoreCase)) ??
                                loadedFontFamilies.FirstOrDefault(f => f.Name.EndsWith(" 5 Medium", StringComparison.OrdinalIgnoreCase)) ??
                                loadedFontFamilies.FirstOrDefault(f => f.Name.EndsWith(" 3 Light", StringComparison.OrdinalIgnoreCase)) ??
                                loadedFontFamilies.FirstOrDefault(f => f.Name.EndsWith(" 2 ExtraLight", StringComparison.OrdinalIgnoreCase)) ??
                                loadedFontFamilies.FirstOrDefault(f => f.Name.EndsWith(" 1 Thin", StringComparison.OrdinalIgnoreCase));
            if (regularFamily != null) return regularFamily.Name;

            // 정규 규칙 이름 없으면 "Regular" 포함 이름 찾기 (Fallback 2)
            regularFamily = loadedFontFamilies.FirstOrDefault(f => f.Name.IndexOf("Regular", StringComparison.OrdinalIgnoreCase) >= 0);
            if (regularFamily != null) return regularFamily.Name;

            // 그것도 없으면 첫 번째 로드된 폰트 (Fallback 3)
            if (loadedFontFamilies.Count > 0) return loadedFontFamilies[0].Name;

            // 최종 실패
            Console.WriteLine("FindBestMatchingFamilyName 오류: 로드된 폰트가 없어 이름을 찾을 수 없습니다.");
            return null;
        }


        /// <summary>
        /// 컨트롤 컬렉션을 재귀적으로 돌며 폰트를 강제로 교체 시도 (내부 사용)
        /// </summary>
        private static void ForceApplyFontRecursively(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                Font originalControlFont = control.Font; // 현재 (Designer.cs 또는 상속된) 폰트

                // 1. 현재 폰트 정보가 있으면 무조건 교체 시도
                if (originalControlFont != null)
                {
                    try
                    {
                        // GetFont 호출 (스타일에 맞는 최적의 폰트 반환 시도)
                        Font newFont = GetFont(originalControlFont.Size, originalControlFont.Style);

                        // 2. 생성된 폰트가 유효하고, 실제로 우리가 로드한 폰트 계열인지 확인
                        //    (GetFont 내부에서 Fallback 발생 시 newFont.Name은 'Malgun Gothic' 등이 됨)
                        if (newFont != null && loadedFontFamilies.Any(f => f.Name.Equals(newFont.Name, StringComparison.OrdinalIgnoreCase)))
                        {
                            // 새 폰트 객체가 기존 객체와 다를 경우에만 할당 (불필요한 리소스 생성 방지)
                            // Font 객체는 비교가 어려우므로 이름, 크기, 스타일로 비교 (더 정확하게 하려면 추가 비교 필요)
                            if (control.Font.Name != newFont.Name || control.Font.Size != newFont.Size || control.Font.Style != newFont.Style)
                            {
                                control.Font = newFont;
                                // Console.WriteLine($"컨트롤 '{control.Name}' ('{control.Text}') 폰트 강제 적용 완료: -> '{control.Font.Name}' ({control.Font.Size}pt, {control.Font.Style})"); // 필요시 주석 해제
                            }
                            else
                            {
                                // 생성했지만 기존 폰트와 동일하면 새로 만든 객체는 해제
                                newFont.Dispose();
                            }
                        }
                        else
                        {
                            // GetFont가 기본 폰트(맑은 고딕)를 반환했거나 실패한 경우
                            // Console.WriteLine($"컨트롤 '{control.Name}' ('{control.Text}') 폰트 강제 적용 실패: GetFont가 '{newFont?.Name ?? "null"}' 반환. (원본: '{originalControlFont.Name}')"); // 필요시 주석 해제
                            newFont?.Dispose(); // 실패 시 생성된 객체 해제
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"컨트롤 '{control.Name}' ('{control.Text}') 폰트 강제 적용 중 오류: {ex.Message}");
                    }
                }

                // 3. 자식 컨트롤 재귀 호출
                if (control.HasChildren)
                {
                    try { ForceApplyFontRecursively(control.Controls); }
                    catch (Exception ex) { Console.WriteLine($"컨트롤 '{control.Name}'의 자식 순회 중 오류: {ex.Message}"); }
                }
            }
        }

        // --- GetDefaultFont는 GetFont를 사용하도록 수정 ---
        public static Font GetDefaultFont(float size, FontStyle style = FontStyle.Regular)
        {
            // GetFont가 알아서 최적의 폰트를 찾도록 위임
            return GetFont(size, style);
        }
    }
}