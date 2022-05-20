﻿namespace TdAmeritrade;

using Models.MarketHours;

public partial class TdAmeritradeApi
{
	/// <summary>
	/// This API allows the developer to get the market hours for a specified single market
	/// </summary>
	/// <param name="market">
	/// The market for which you're requesting market hours. Valid markets are EQUITY, OPTION, FUTURE, BOND, or FOREX.
	/// </param>
	/// <param name="date">
	/// The date for which market hours information is requested. Valid ISO-8601 formats are: <c>yyyy-MM-dd</c> and <c>yyyy-MM-dd'T'HH:mm:ssz</c>.
	/// </param>
	/// <returns>
	/// If successful, the return includes information about the hours of the market.
	/// </returns>
	/// <exception cref="ApiException" />
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/market-hours/apis/get/marketdata/%7Bmarket%7D/hours"/>
	/// </remarks>
	public Task<IReadOnlyDictionary<string, MarketHoursResponse>> GetMarketHours(string market, DateOnly? date = default) =>
		GetMarketHours(refreshToken: default, market, date);

	/// <summary>
	/// This API allows the developer to get the market hours for a specified single market
	/// </summary>
	/// <param name="refreshToken">A refresh token generated by TD Ameritrade APIs for authentication.</param>
	/// <param name="market">
	/// The market for which you're requesting market hours. Valid markets are EQUITY, OPTION, FUTURE, BOND, or FOREX.
	/// </param>
	/// <param name="date">
	/// The date for which market hours information is requested. Valid ISO-8601 formats are: <c>yyyy-MM-dd</c> and <c>yyyy-MM-dd'T'HH:mm:ssz</c>.
	/// </param>
	/// <returns>
	/// If successful, the return includes information about the hours of the market.
	/// </returns>
	/// <exception cref="ApiException" />
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/market-hours/apis/get/marketdata/%7Bmarket%7D/hours"/>
	/// </remarks>
	public async Task<IReadOnlyDictionary<string, MarketHoursResponse>> GetMarketHours(string? refreshToken, string market, DateOnly? date = default)
	{
		var dateStr = date?.ToString("yyyy'-'MM'-'dd", System.Globalization.CultureInfo.InvariantCulture);

		refreshToken ??= _refreshToken;
		if (refreshToken == null)
			return await _api.GetMarketHours(authorization: default, _clientId, market, dateStr).ConfigureAwait(false);

		var accessToken = await GetAccessToken(refreshToken).ConfigureAwait(false);
		return await _api.GetMarketHours(accessToken, apikey: default, market, dateStr).ConfigureAwait(false);
	}

	/// <summary>
	/// This API allows the developer to get the market hours for a multiple markets
	/// </summary>
	/// <param name="markets">
	/// The markets for which you're requesting market hours, comma-separated. Valid markets are EQUITY, OPTION, FUTURE, BOND, or FOREX.
	/// </param>
	/// <param name="date">
	/// The date for which market hours information is requested. Valid ISO-8601 formats are: <c>yyyy-MM-dd</c> and <c>yyyy-MM-dd'T'HH:mm:ssz</c>.
	/// </param>
	/// <returns>
	/// If successful, the return includes information about the hours of the market.
	/// </returns>
	/// <exception cref="ApiException" />
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/market-hours/apis/get/marketdata/hours"/>
	/// </remarks>
	public Task<IReadOnlyDictionary<string, MarketHoursResponse>> GetMarketHours(IReadOnlyList<string> markets, DateOnly? date = default) =>
		GetMarketHours(refreshToken: default, markets, date);

	/// <summary>
	/// This API allows the developer to get the market hours for a multiple markets
	/// </summary>
	/// <param name="refreshToken">A refresh token generated by TD Ameritrade APIs for authentication.</param>
	/// <param name="markets">
	/// The markets for which you're requesting market hours, comma-separated. Valid markets are EQUITY, OPTION, FUTURE, BOND, or FOREX.
	/// </param>
	/// <param name="date">
	/// The date for which market hours information is requested. Valid ISO-8601 formats are: <c>yyyy-MM-dd</c> and <c>yyyy-MM-dd'T'HH:mm:ssz</c>.
	/// </param>
	/// <returns>
	/// If successful, the return includes information about the hours of the market.
	/// </returns>
	/// <exception cref="ApiException" />
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/market-hours/apis/get/marketdata/hours"/>
	/// </remarks>
	public async Task<IReadOnlyDictionary<string, MarketHoursResponse>> GetMarketHours(string? refreshToken, IReadOnlyList<string> markets, DateOnly? date = default)
	{
		var dateStr = date?.ToString("yyyy'-'MM'-'dd", System.Globalization.CultureInfo.InvariantCulture);

		refreshToken ??= _refreshToken;
		if (refreshToken == null)
			return await _api.GetMarketHours(authorization: default, _clientId, markets, dateStr).ConfigureAwait(false);

		var accessToken = await GetAccessToken(refreshToken).ConfigureAwait(false);
		return await _api.GetMarketHours(accessToken, apikey: default, markets, dateStr).ConfigureAwait(false);
	}
}
