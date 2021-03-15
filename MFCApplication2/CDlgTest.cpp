// CDlgTest.cpp: 구현 파일
//

#include "pch.h"
#include "MFCApplication2.h"
#include "CDlgTest.h"
#include "afxdialogex.h"
#include "afxwinappex.h"


// CDlgTest 대화 상자

IMPLEMENT_DYNAMIC(CDlgTest, CDialogEx)

CDlgTest::CDlgTest(CWnd* pParent /*=nullptr*/)	: CDialogEx(IDD_DLG_TEST, pParent)
{
}

CDlgTest::~CDlgTest()
{
}

void CDlgTest::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CDlgTest, CDialogEx)
	ON_BN_CLICKED(IDOK, &CDlgTest::OnBnClickedOk)
	ON_EN_CHANGE(IDC_EDIT1, &CDlgTest::OnEnChangeEdit1)
	ON_BN_CLICKED(IDC_BUTTON1, &CDlgTest::OnBnClickedButton1)

END_MESSAGE_MAP()


// CDlgTest 메시지 처리기


BOOL CDlgTest::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// TODO:  여기에 추가 초기화 작업을 추가합니다.
	CFont f;
	//f.CreateFont(72, 0, 0, 0, FW_BOLD, true, TRUE, FALSE, DEFAULT_CHARSET, OUT_OUTLINE_PRECIS,
	//	CLIP_DEFAULT_PRECIS, CLEARTYPE_QUALITY, VARIABLE_PITCH, L"Times New Roman");
	f.CreateFont(72, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, TEXT("Arial"));
	GetDlgItem(IDC_STATIC_TEST1)->SetFont(&f,1);
	f.Detach();
	return TRUE;  // return TRUE unless you set the focus to a control
				  // 예외: OCX 속성 페이지는 FALSE를 반환해야 합니다.
}


void CDlgTest::OnBnClickedOk()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	CDialogEx::OnOK();
}


void CDlgTest::OnEnChangeEdit1()
{
	// TODO:  RICHEDIT 컨트롤인 경우, 이 컨트롤은
	// CDialogEx::OnInitDialog() 함수를 재지정 
	//하고 마스크에 OR 연산하여 설정된 ENM_CHANGE 플래그를 지정하여 CRichEditCtrl().SetEventMask()를 호출하지 않으면
	// 이 알림 메시지를 보내지 않습니다.

	// TODO:  여기에 컨트롤 알림 처리기 코드를 추가합니다.
}

void CDlgTest::OnBnClickedButton1()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.

	CString fPath, fName,s;
	CFileDialog *dlg = new CFileDialog(true, NULL, L"*.*", OFN_HIDEREADONLY | OFN_OVERWRITEPROMPT,L"*.*", NULL);
	if (dlg->DoModal() == IDOK)
	{
		fPath = dlg->GetPathName();
		fName = dlg->GetFileName();

		CFile f;
		f.Open(fPath, CFile::modeRead);
		int n = f.GetLength();
		char *buf = new char[n];
		WCHAR *wBuf = new WCHAR[n];
		f.Read(buf, n);
		//s.Format(L"%s", buf);
		wBuf[MultiByteToWideChar(CP_ACP, 0, buf, n, wBuf, n)] = 0;
		GetDlgItem(IDC_EDIT1)->SetWindowText(wBuf);
		delete wBuf;
		delete buf;
	}
}
