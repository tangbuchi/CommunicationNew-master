#ifndef __COMM_NET_H
#define __COMM_NET_H

#ifndef DSCDLLAPI
#define DSCDLLAPI  extern "C"
#endif

typedef long           int32;	/* 32-bit signed integer */
typedef unsigned int   uint;	/* 16 or 32-bit unsigned integer */
typedef unsigned long  uint32;	/* 32-bit unsigned integer */
typedef unsigned short uint16;	/* 16-bit unsigned integer */
typedef unsigned char  byte_t;	/*  8-bit unsigned integer */
typedef unsigned char  uint8;	/*  8-bit unsigned integer */

#define MAX_RECEIVE_BUF 1024  //the max data packet length that would be received
//add by sea On Nov 14,2002
#define MAX_SEND_BUF MAX_RECEIVE_BUF  //the max data packet length that would be sent

#define DEFAULT_CLIENT_PORT 5001 //the default monitoring port on terminal

#define HDCALL WINAPI//__stdcall
/*
 * user info interface
 */
typedef struct GPRS_USER_INFO{
	char       m_userid[12];   	//DTU Identify number
	uint32     m_sin_addr;     	//the ip address of DTU in Internet,maybe a gateway ip addr
	uint16     m_sin_port;     	//the ip port of DTU in Internet
	uint32     m_local_addr;   	//the ip address of DTU in local mobile net
	uint16     m_local_port;   	//the local port of DTU in local mobile net
	char       m_logon_date[20]; 	//the date that the DTU logon 
	char	   m_update_time[20]; //the last date that receive IP packet
	uint8	   m_status;		//DTU status, on line 1 : offline 0
	//char m_peer_id[12];  //relative mobile terminal identity number
}user_info;
/*
 * user data record interface
 * as param when call function do_read_proc()
 */
typedef struct GPRS_DATA_RECORD{
	char       m_userid[12];		//DTU Identify number
	char       m_recv_date[20];		//the date that receive data packet
	char       m_data_buf[MAX_RECEIVE_BUF]; //store data packet
	//char       m_data_buf[MAX_RECEIVE_BUF+1]; //store data packet
	uint16     m_data_len;			//the data length
	uint8      m_data_type;	//data type,if 0 unknown type, 0x01 logon data type,0x02 logout data type,0x09 user data type
}data_record;
/*
 * Get the user amount in user list
 * return uint
 */
DSCDLLAPI  uint HDCALL get_max_user_amount();
/*
 * Get the online user amount in user list
 */
DSCDLLAPI  uint HDCALL get_online_user_amount();
/*
 * Get the user info in user list, if exist 0,else -1
 * @param userid: 	[in] The user's identity number. 
 * @param infoPtr:	[out] A pointer to a buffer that receives the user info
 */
DSCDLLAPI  int HDCALL get_user_info(uint8 *userid,user_info *infoPtr);

/*
 * Get a user's info at one position 
 * @param index: 	[in] 0 ~ get_max_user_amount().
 * @param infoPtr:	[out] A pointer to a buffer that receives the user info
 */
DSCDLLAPI  int HDCALL get_user_at(uint index,user_info *infoPtr);
/*
 * Get Local Host Name
 * @param namebuf:	[out] A pointer to a buffer that receives the local host name
 * @param len: 		[in] The length of the buffer. 
 * @param mess:		[out] A pointer to a buffer that store error message
 * return -1 error,0 successfully
 */
DSCDLLAPI  int HDCALL get_server_name(char *namebuf,int len,char *mess);
/*
 * Start net service
 * hWnd  A handle identifying the window that will receive a message when a network event occurs. 
 * wMsg  The message to be received when a network event occurs. 
 *	    default value: const int WM_CLIENT_READCLOSE=WM_USER+105;
 * nServerPort network monitor port,default 5002
 * @param mess:		[out] A pointer to a buffer that store error message
 */
DSCDLLAPI int HDCALL start_gprs_server(HWND hWnd,unsigned int wMsg,int nServerPort,char *mess);
/*
 * Stop net service
 * @param mess:		[out] A pointer to a buffer that store error message
 * return -1 failed or nonexistent,0 successful
 */
DSCDLLAPI int HDCALL stop_gprs_server(char *mess);
/*
 * Process all data from DTU
 * @param recdPtr: 	[out] A pointer to a struct that store dtu data info
 * @param mess:		[out] A pointer to a buffer that store message
 * @param reply: 	[in] The flag that used to indicate answer or not answer the dtu when it receive dtu data. 
 * return -1 failed,0 successful
 */
DSCDLLAPI int HDCALL do_read_proc(data_record *recdPtr,char *mess,BOOL reply);
/*
 * 取消do_read_proc函数的阻塞状态。SetWorkMode(0)时使用
 */
DSCDLLAPI void HDCALL cancel_read_block();
/*
 * Send data to DTU
 * @param userid: 	[in] The user's identity number. 
 * @param data:	[in] The data that will be sent
 * @param len: 	[in] The length of the data. 
 * @param mess:		[out] A pointer to a buffer that store error message
 * return -1 failed,0 successful
 */
DSCDLLAPI int HDCALL do_send_user_data(uint8* userid,uint8*data,uint len,char *mess);
/*
 * Close one DTU in current user list but not really send close command to dtu
 * @param userid: 	[in] The user's identity number. 
 * @param mess:		[out] A pointer to a buffer that store error message
 * return -1 failed or nonexistent,0 successful
 */
DSCDLLAPI int HDCALL do_close_one_user(uint8* userid,char *mess);
/*
 * Close all DTU in current user list but not really send close command to dtu
 * @param mess:		[out] A pointer to a buffer that store error message
 * return -1 failed or nonexistent,0 successful
 */
DSCDLLAPI int HDCALL do_close_all_user(char *mess);
/*
 * Close one DTU in current user list and send close command to dtu
 * @param userid: 	[in] The user's identity number. 
 * @param mess:		[out] A pointer to a buffer that store error message
 * return -1 failed or nonexistent,0 successful
 */
DSCDLLAPI int HDCALL do_close_one_user2(uint8* userid,char *mess);
/*
 * Close all DTU in current user list and send close command to dtu
 * @param mess:		[out] A pointer to a buffer that store error message
 * return -1 failed or nonexistent,0 successful
 */
DSCDLLAPI int HDCALL do_close_all_user2(char *mess);

int init_gprs_comm(int nServerPort,char *mess);
int Verify_Packet(unsigned char *recv,unsigned char *userid,int *len);

//if u want to reload the function and implement your user list,u can use these functions to send protocol packet to DTU
/*
 * type 1: answer DTU logon ok
 * type 2: answer DTU logout ok or let DTU logout
 * type 3: 
 * type 4: DTU send invalid cmd to DSC
 * type 5: DTU receive correct data packet
*/
DSCDLLAPI int HDCALL send_cmd(const unsigned long destIP,const unsigned short destPort,unsigned char *userid,unsigned char type);
/*
 * send user data to DTU
 * @destIP:		[in] DTU IP address
 * @destPort:	[in] DTU IP port
 * @param data:		[out] A pointer to a buffer that store user data
 * @param len: 		[in] The length of the buffer. 
 */
DSCDLLAPI int HDCALL send_data(const unsigned long destIP,const unsigned short destPort,unsigned char *userid,unsigned char *data,unsigned int len);

/*
typedef void (HDCALL* EVTCALLBACK)(user_info *m_userPtr);
DSCDLLAPI void HDCALL SetEvtCALLBACK (EVTCALLBACK logonProc,EVTCALLBACK logoutProc,
		EVTCALLBACK RecvUserDataProc,EVTCALLBACK RecvDTUAnswerProc,EVTCALLBACK InvalidCmdProc);
*/
/*
 * if u want to discard the default DTU maintenance list and implement the list of 
 * yourself,u can reload the functions below 
 */
typedef void (HDCALL* LOGONCALLBACK)(user_info *m_userPtr);
typedef void (HDCALL* LOGOUTCALLBACK)(user_info *m_userPtr);
typedef void (HDCALL* RECVDATACALLBACK)(user_info *m_userPtr,data_record *recdPtr,BOOL bReply);
typedef void (HDCALL* RECVDATAREPLYCALLBACK)(user_info *m_userPtr);
typedef void (HDCALL* INVALIDCMDCALLBACK)(user_info *m_userPtr);
DSCDLLAPI void HDCALL SetLogonCALLBACK (LOGONCALLBACK logonProc);
DSCDLLAPI void HDCALL SetLogoutCALLBACK (LOGOUTCALLBACK logonProc);
DSCDLLAPI void HDCALL SetRecvdataCALLBACK (RECVDATACALLBACK logonProc);
DSCDLLAPI void HDCALL SetRecvDataReplyCALLBACK (RECVDATAREPLYCALLBACK logonProc);
DSCDLLAPI void HDCALL SetInvalidcmdCALLBACK (INVALIDCMDCALLBACK logonProc);
DSCDLLAPI void HDCALL SetEvtCALLBACK(
        LOGONCALLBACK logonProc,LOGOUTCALLBACK logoutProc,
		RECVDATACALLBACK RecvUserDataProc,RECVDATAREPLYCALLBACK RecvDTUReplyProc,
		INVALIDCMDCALLBACK InvalidCmdProc);

/*
 *  DTU短信呼叫时，此方法用于向gprs_dll.dll发送DTU呼叫通知
 */
int DTUCallServer(data_record *,char *,int);

/*
 *  下边一组函数用于IP过滤，排除本机上局域网IP，那么
 *  剩下的一个就是公众的IP；对于拨号上网，因为其IP是
 *  不固定的，所有只要将本机固定的局域网IP添加到过滤
 *  表中，服务启动时，会读取系统所有的IP，找到一个不
 *  在过滤表中的IP作为服务器实际的IP；
 */

//  添加一个局域网IP
int AddFilterIP(unsigned long ulIPAddr);

//  删除一个局域网IP，如果参数为0，则删除全部IP；
int DelFilterIP(unsigned long ulIPAddr=0);

//  查找某个IP是否在过滤表中，返回值为其索引，如果不在，
//  返回－1；
int FindFilterIP(unsigned long ulIPAddr);

//  获得当前过滤表中局域网IP地址的数量
int GetFilterIPCount(void);

//  获得过滤表中某个位置的IP值；
unsigned long GetIP(int iIndex);

//  获得当前系统使用的IP
unsigned long GetCurrentIP(void);

//  指定使用的IP
DSCDLLAPI void HDCALL SetCustomIP(unsigned long ulIPAddr);

/*
 *  服务启动后，调用AddOneUser函数可向系统的用户表中
 *  添加一个用户，这样可以省略掉DTU向中心登录的过程；
 *  该情况适用于中心重启后，而DTU并没有立即登录，中心
 *  为了保持和DTU之间的联系，用户可调用函数AddOneUser
 *  向用户列表中手工添加用户；
 */
DSCDLLAPI void HDCALL DeleteAllUser(void);
DSCDLLAPI int HDCALL AddOneUser(user_info * pUserInfo);


/*
 *Add by SEA on Oct 28,2003
 *Modified by SEA Oct 29,2003
 *Setup work mode
 *@param nWorkMode: 		[in] The Mode of dll working. 
 *0-use blocking mode and uses thread to receive data
 *1-use nonblocking mode,not need windows's handle and message
 *2-use nonblocking mode,must transfer valid window's handle and message
 *default value is 2 ,it is compatible with previous version
 */

DSCDLLAPI int  HDCALL SetWorkMode(int nWorkMode);

/*新增加函数，
该函数的作用是：选择通讯协议
必须在start_gprs_server函数前调用才有效
0	UDP
1	TCP
*/
DSCDLLAPI int  HDCALL SelectProtocol(int nProtocol);

////////////////////////////////////////////////////////////////////////////////
	
//参数配置函数组
//清除设置参数
DSCDLLAPI void  HDCALL ClearParam();
//加入设置参数，0失败，1成功
DSCDLLAPI int  HDCALL SetParam(int nParamType, char *cpValue, int nParamLenth, int *iErrorCode);
//更新dtu参数，0失败，1成功
//destIP: DTU的IP地址(主机字节顺序)
//destPort: DTU的端口(主机字节顺序)
DSCDLLAPI int  HDCALL DoUpdateParam(const unsigned long destIP,const unsigned short destPort, char *m_userid);
//读取DTU参数，0失败，1成功
DSCDLLAPI int  HDCALL DoReadParam(const unsigned long destIP,const unsigned short destPort, char *m_userid);
//读取dtu某项参数，0失败，1成功
//nParamLenth表示参数长度
DSCDLLAPI int  HDCALL GetParam(int nParamType, char *cpValue, int *nParamLenth);

////////////used to maintian user list//////////////////////////////////////////////////////////
/*
 *  服务启动后，调用add_one_user函数可向系统的用户表中
 *  添加一个用户，这样可以省略掉DTU向中心登录的过程；
 *  该情况适用于中心重启后，而DTU并没有立即登录，中心
 *  为了保持和DTU之间的联系，用户可调用函数add_one_user
 *  向用户列表中手工添加用户；
 *  return -1 failed,0 successful
 *  This function used to replace function AddOneUser();
 */
DSCDLLAPI int HDCALL add_one_user(user_info * pUserInfo);
/*
 * it will delete all users in user list
 * return -1 failed or nonexistent,0 successful
 *  This function used to replace function DeleteAllUser();
 */
DSCDLLAPI int HDCALL delete_all_user(void);
/*
 * Delete one user in user list
 * Close one DTU in current user list but no really send close command to DTU
 * return -1 failed or nonexistent,0 successful
 */
DSCDLLAPI int HDCALL delete_one_user(uint8* userid,char *mess);
////////////////////////////////////////////////////////////////////////////////
/*
 * Start net service
 * @param hWnd  A handle identifying the window that will receive a message when a network event occurs. 
 * @param wMsg  The message to be received when a network event occurs. 
 *	    default value: const int WM_CLIENT_READCLOSE=WM_USER+105;
 * @param nServerPort network monitor port,default 5002
 * @param mess:		[out] A pointer to a buffer that store error message
 *  This function used to replace function start_gprs_server();
 */
DSCDLLAPI int HDCALL start_net_service(HWND hWnd,unsigned int wMsg,int nServerPort,char *mess);
/*
 * Stop net service
 * @param mess:		[out] A pointer to a buffer that store error message
 * return -1 failed or nonexistent,0 successful
 *  This function used to replace function stop_gprs_server();
 */
DSCDLLAPI int HDCALL stop_net_service(char *mess);
/*
 * Update DTU parameters,the DTU always response it
 * @param userid: 	[in] The user's identity number. 
 * @param mess:		[out] A pointer to a buffer that store error message
 * return -1 failed or nonexistent,0 successful
 */
DSCDLLAPI int HDCALL do_update_param(uint8* userid,char *mess);
/*
 * Read DTU parameters
 * @param userid: 	[in] The user's identity number. 
 * @param qtype: 	[in] The option that will be queried. 0x00 query all parameters
 * @param mess:		[out] A pointer to a buffer that store error message
 * return -1 failed or nonexistent,0 successful
 */
DSCDLLAPI int HDCALL do_read_param(uint8* userid,uint8 qtype,char *mess);
/*
 * Added by SEA on Feb 28,2005
 * Send command to remote DTU,the DTU always response it
 * The DTU will disconnect ppp link and wait to redial(when setup reconnect interval)
 * @param mess:		[out] A pointer to a buffer that store error message
 * return -1 failed or nonexistent,0 successful
 */
DSCDLLAPI int HDCALL do_disconnect_ppp_link(uint8* userid,char *mess);
/*
 * Added by SEA on Feb 28,2005
 * Send command to remote DTU,the DTU always response it
 * The DTU will stop to send data to DSC
 * @param mess:		[out] A pointer to a buffer that store error message
 * return -1 failed or nonexistent,0 successful
 */
DSCDLLAPI int HDCALL do_stop_send_data(uint8* userid,char *mess);
/*
 * Added by SEA on Feb 28,2005
 * Send command to remote DTU,the DTU always response it
 * The DTU will start to send data to DSC
 * @param mess:		[out] A pointer to a buffer that store error message
 * return -1 failed or nonexistent,0 successful
 */
DSCDLLAPI int HDCALL do_start_send_data(uint8* userid,char *mess);
/*
 * Added by SEA on Feb 28,2005
 * Send command to remote DTU,the DTU always response it
 * The data in DTU cache will be discarded
 * @param mess:		[out] A pointer to a buffer that store error message
 * return -1 failed or nonexistent,0 successful
 */
DSCDLLAPI int HDCALL do_flush_cache_data(uint8* userid,char *mess);

DSCDLLAPI int HDCALL do_change_chlctrllevel_mem(uint8* userid,uint8 chl1, uint8 chl2, uint8 chl3, uint8 chl4, char *mess);

DSCDLLAPI int HDCALL do_read_log(uint8* userid, uint16 usBegin, uint16 usCount, char *mess);

DSCDLLAPI void HDCALL InvokeParamUI(HWND  hParentWnd);

DSCDLLAPI void HDCALL InvokeLogUI(HWND  hParentWnd);

DSCDLLAPI void HDCALL InvokeUpdateUI(HWND  hParentWnd);

////////////////////////////////////////////////////////////////////////////////////////////////////

#endif
