#pragma once
#include <string>
#include <vector>
#include <Windows.h>
#include "aitalk_AITalk.h"

using namespace System;
using namespace Runtime::InteropServices;

namespace AITalkWrapper {
    public ref class AITalkWrapper {
    public:
        // �����f�[�^�x�[�X�̃T���v�����[�g [Hz]
        literal int VoiceDbSampleRate = 44100;

        // �W���̃^�C���A�E�g [ms]
        literal int DefaultTimeOut = 10000;

        // �f�X�g���N�^
        ~AITalkWrapper();

        // �G���[��������擾����
        String^ GetLastError(void);

        // AITalk���C�u�������J��
        bool OpenLibrary(String ^install_path, String ^auth_code_seed, int timeout);

        // AITalk���C�u���������
        void CloseLibrary(void);

        // AITalk���C�u����������ɊJ�������擾����
        bool IsLibraryOpened(void);
        
        // ����t�@�C����ǂݍ���
        bool LoadLanguage(String ^language_name);

        // �t���[�Y������ǂݍ���
        bool LoadPhraseDictionary(String ^path);

        // �P�ꎫ����ǂݍ���
        bool LoadWordDictionary(String ^path);

        // �L���|�[�Y������ǂݍ���
        bool LoadSymbolDictionary(String ^path);

        // �{�C�X���C�u������ǂݍ���
        bool LoadVoice(String ^voice_name);

        // ���͂������ɕϊ�����
        String^ TextToKana(String ^text, int timeout);

        // �����������ɕϊ�����
        array<Byte>^ KanaToSpeech(String ^kana, int timeout);

        // �����������ɕϊ�����
        // �ϊ��C�x���g���󂯎��
        array<Byte>^ KanaToSpeech(String ^kana, int timeout, [Out] array<Tuple<UInt64, String^>^> ^%event);

    private:
        // ���j�R�[�h�������Shift-JIS�ɕϊ����AShift-JIS�̊e�o�C�g�����j�R�[�h������̉������ڂɑΉ����邩��Ԃ�
        bool UnicodeToShiftJIS(const std::wstring &unicode_string, std::string *ascii_string, std::vector<int> *ascii_to_unicode);

        // ���̃��b�p�[���C�u����������������
        void InitializeAll(void);

        // �G���[���������������
        void ClearLastError(void);

        // �G���[�������ݒ肷��
        void SetLastError(String ^text);

        // �G���[������
        String ^ErrorString = L"";

        // VOICEROID2�̃C���X�g�[���f�B���N�g��
        String ^InstallDirectory = L"";

        // aitalked.dll�̃��W���[���n���h��
        HMODULE ModuleHandle = NULL;

        // aitalked.dll�̊֐�
        AITalkResultCode(__stdcall *AITalkAPI_CloseKana)(int32_t, int32_t) = nullptr;
        AITalkResultCode(__stdcall *AITalkAPI_CloseSpeech)(int32_t, int32_t) = nullptr;
        AITalkResultCode(__stdcall *AITalkAPI_End)(void) = nullptr;
        AITalkResultCode(__stdcall *AITalkAPI_GetData)(int32_t, int16_t*, uint32_t, uint32_t*) = nullptr;
        AITalkResultCode(__stdcall *AITalkAPI_GetKana)(int32_t, char*, uint32_t, uint32_t*, uint32_t*) = nullptr;
        AITalkResultCode(__stdcall *AITalkAPI_GetParam)(AITalk_TTtsParam*, uint32_t*) = nullptr;
        AITalkResultCode(__stdcall *AITalkAPI_Init)(AITalk_TConfig*) = nullptr;
        AITalkResultCode(__stdcall *AITalkAPI_LangClear)(void) = nullptr;
        AITalkResultCode(__stdcall *AITalkAPI_LangLoad)(const char*) = nullptr;
        AITalkResultCode(__stdcall *AITalkAPI_LicenseDate)(char*) = nullptr;
        AITalkResultCode(__stdcall *AITalkAPI_LicenseInfo)(const char*, char*, uint32_t, uint32_t*) = nullptr;
        AITalkResultCode(__stdcall *AITalkAPI_ReloadPhraseDic)(const char*) = nullptr;
        AITalkResultCode(__stdcall *AITalkAPI_ReloadSymbolDic)(const char*) = nullptr;
        AITalkResultCode(__stdcall *AITalkAPI_ReloadWordDic)(const char*) = nullptr;
        AITalkResultCode(__stdcall *AITalkAPI_SetParam)(const AITalk_TTtsParam*) = nullptr;
        AITalkResultCode(__stdcall *AITalkAPI_TextToKana)(int32_t*, AITalk_TJobParam*, const char*) = nullptr;
        AITalkResultCode(__stdcall *AITalkAPI_TextToSpeech)(int32_t*, AITalk_TJobParam*, const char*) = nullptr;
        AITalkResultCode(__stdcall *AITalkAPI_VersionInfo)(int32_t, char*, uint32_t, uint32_t*) = nullptr;
        AITalkResultCode(__stdcall *AITalkAPI_VoiceClear)(void) = nullptr;
        AITalkResultCode(__stdcall *AITalkAPI_VoiceLoad)(const char*) = nullptr;
    };
}
