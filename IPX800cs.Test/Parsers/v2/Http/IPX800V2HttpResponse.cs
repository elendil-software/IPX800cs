namespace IPX800cs.Test.Parsers.v2.Http;

public static class IPX800V2HttpResponse
{
    internal const string Xml = @"<response>
<led0>1</led0>
<led1>0</led1>
<led2>1</led2>
<led3>0</led3>
<led4>0</led4>
<led5>0</led5>
<led6>0</led6>
<led7>0</led7>
<btn0>up</btn0>
<btn1>up</btn1>
<btn2>dn</btn2>
<btn3>dn</btn3>
<an1>0</an1>
<an2>1</an2>
<day>3</day>
<time0>18:57:54</time0>
<count1>1</count1>
<count2>1</count2>
<config_hostname>RELAYBOARD</config_hostname>
<config_dhcpchecked>checked</config_dhcpchecked>
<config_mac>00:1E:C0:D5:F8:DD</config_mac>
<config_ip>192.168.0.5</config_ip>
<config_gw>192.168.0.1</config_gw>
<config_subnet>255.255.255.0</config_subnet>
<config_dns1>192.168.0.1</config_dns1>
<config_dns2>0.0.0.0</config_dns2>
<firmware_version>3.00.29</firmware_version>
<http_port>80</http_port>
<ntp_server>pool.ntp.org</ntp_server>
<ntp_port>123</ntp_port>
<smtp_server>smtp.gce-electronics.com</smtp_server>
<smtp_port>25</smtp_port>
<smtp_user>test@gce-electronics.com</smtp_user>
<smtp_pass>123456</smtp_pass>
<email_dest>your_email</email_dest>
</response>";
}