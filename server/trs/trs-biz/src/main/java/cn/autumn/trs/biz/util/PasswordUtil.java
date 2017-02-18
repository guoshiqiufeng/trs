package cn.autumn.trs.biz.util;

import java.util.HashSet;
import java.util.Set;

import org.apache.commons.codec.digest.DigestUtils;
import org.apache.commons.lang3.StringUtils;

public final class PasswordUtil
{

	private static final String SYMBOL = "\\~\\!\\@\\#\\$\\%\\^&\\*()_\\+\\{\\}\\|\\:\\\\\"\\<\\>\\?\\-\\=\\[\\]\\;\\'\\,\\.\\/\\'";
	private static final String SYMBOL_REG = ".*[\\~\\!\\@\\#\\$\\%\\^&\\*()_\\+\\{\\}\\|\\:\\\\\"\\<\\>\\?\\-\\=\\[\\]\\;\\'\\,\\.\\/\\']+.*";
	private static final String UPPER_CASE_CHARS = ".*[A-Z]+.*";
	private static final String LOWER_CASE_CHARS = ".*[a-z]+.*";
	private static final String NUMBERS = ".*[0-9]+.*";
	private static final String PASSWORD_REGEX[] = {
		".*[\\~\\!\\@\\#\\$\\%\\^&\\*()_\\+\\{\\}\\|\\:\\\\\"\\<\\>\\?\\-\\=\\[\\]\\;\\'\\,\\.\\/\\']+.*", ".*[A-Z]+.*", ".*[a-z]+.*", ".*[0-9]+.*"
	};
	private static final int MIN_PASSWORD_LENGTH = 8;

	private PasswordUtil()
	{
	}

	public static String encrypt(String password)
	{
		return DigestUtils.md5Hex(password);
	}

	public static boolean isValidPassword(String password)
	{
		if (StringUtils.length(password) < 8)
			return false;
		if (!password.matches("([\\~\\!\\@\\#\\$\\%\\^&\\*()_\\+\\{\\}\\|\\:\\\\\"\\<\\>\\?\\-\\=\\[\\]\\;\\'\\,\\.\\/\\']|[a-zA-Z0-9])+"))
			return false;
		Set matchedRegs = new HashSet();
		String arr$[] = PASSWORD_REGEX;
		int len$ = arr$.length;
		for (int i$ = 0; i$ < len$; i$++)
		{
			String reg = arr$[i$];
			if (password.matches(reg))
				matchedRegs.add(reg);
		}

		return matchedRegs.size() >= 3;
	}

}
