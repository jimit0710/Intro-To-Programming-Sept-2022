﻿using System.Text.RegularExpressions;
using apiModels = Banking.Api.Models;

namespace Banking.IntegrationTests;
public class AddingNewAccounts
{
    [Fact]
    public async Task AddingANewAccount()
    {
        // add a new account through the api.
        // verify we get back:
        // 201 Status Code
        // Location Header with the URI of the new resource
        // And a copy of the resource, with an ID
        // Request it again from the API, but get it's subordinate resource /balance
        // verify it is 5000
        // Given
        var newAccount = new apiModels.AccountCreateRequest { Name = "Sue Jones" };

        await using var host = await AlbaHost.For<global::Program>(config => { });

        var result = await host.Scenario(api =>
        {
            api.Post.Json(newAccount).ToUrl("/accounts");
            api.StatusCodeShouldBe(201);
            api.ContentTypeShouldBe("application/json; charset=utf-8");
            api.Header("Location")
            .SingleValueShouldMatch(new Regex(@"^http://localhost/accounts/\w*"));
        });

        var response = result.ReadAsJson<apiModels.AccountSummaryResponse>();

        Assert.Equal(newAccount.Name, response?.Name);
        Assert.NotNull(response?.Id);
        var newId = response.Id;

        var balanceResult = await host.Scenario(api =>
        {
            // /accounts/83989389389/balance
            api.Get.Url($"/accounts/{newId}/balance");
            api.StatusCodeShouldBeOk();
            api.ContentTypeShouldBe("application/json; charset=utf-8");
        });

        var balanceResponse = balanceResult.ReadAsJson<apiModels.AccountBalanceResponse>();

        Assert.Equal(5000M, balanceResponse?.Balance);


        var depositToPost = new apiModels.AccountTransactionRequest { Amount = 100M };

        var depositResponse = await host.Scenario(api =>
        {
            api.Post.Json(depositToPost).ToUrl($"/accounts/{newId}/deposits");
            api.StatusCodeShouldBe(201);
            // check the location header, all that jazz... TODO
        });

        var transactionResult = depositResponse.ReadAsJson<apiModels.AccountTransactionResponse>();
        // look at all the properties...

        Assert.Equal(DateTime.Now, transactionResult?.PostedAt);

        // POST /accounts/83983983/deposits
        // { "amount": 300 }

        // 201
        // { "transactionId": "i939839", "postedAt": "some date time", "amount": 300, "type": "DEPOSIT" }
    }

}