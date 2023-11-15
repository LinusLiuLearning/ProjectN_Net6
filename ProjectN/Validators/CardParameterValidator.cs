using FluentValidation;
using Microsoft.VisualBasic;
using ProjectN.Parameter;

namespace ProjectN.Validators
{
    /// <summary>
    /// Card Parameter 的驗證器
    /// </summary>
    public class CardParameterValidator: AbstractValidator<CardParameter>
    {
        /// <summary>
        /// 驗證器的建構式: 在這裡註冊我們要驗證的規則
        /// </summary>
        public CardParameterValidator()
        {
            #region 範例
            //this.RuleFor(card => card.Attack).Cascade(CascadeMode.Stop).GreaterThanOrEqualTo(0);

            // 驗證失敗時即停止
            //RuleLevelCascadeMode = FluentValidation.CascadeMode.Stop;

            // 目標：當 卡牌 是 怪獸卡 的時候，攻擊力不可為 Null 

            //this.RuleFor(card => card.Attack).GreaterThanOrEqualTo(0).WithMessage("卡片的攻擊力不可為負數");
            //this.RuleFor(card => card.Attack).GreaterThanOrEqualTo(0).WithName("攻擊力").WithMessage("卡片的{PropertyName}不可為負數");

            // 目標：當 卡牌 是 怪獸卡 的時候，攻擊力不可為 Null
            // 目標：當 卡牌 不是 怪獸卡 的時候，攻擊力必須為 Null
            //this.When(card => card.CardType is CardType.Monster, () =>
            //{
            //    this.RuleFor(card => card.Attack).NotNull();
            //})
            //.Otherwise(() =>
            //{
            //    this.RuleFor(card => card.Attack).Null();
            //});

            //this.RuleForEach(card => card.Alias).NotEmpty(); // 不可為空

            // 使用 Must 來自訂規則
            //this.RuleFor(card => card.Attack).Must(attack => attack > 0 && attack <= 3000);

            //this.RuleFor(card => card.Equipment).SetValidator(new EquipmentValidator());

            // Fluent Validation 的 驗證器請參照
            // https://docs.fluentvalidation.net/en/latest/built-in-validators.html

            // 驗證失敗時即停止
            //this.CascadeMode = FluentValidation.CascadeMode.Stop;

            // 為了示範所以做成變數，平時可以直接 RuleFor().XXX() 串接驗證器即可
            //var name = this.RuleFor(card => card.Name);
            //var cost = this.RuleFor(card => card.Cost);
            //var type = this.RuleFor(card => card.Type);

            // 不可為 Null    
            //name.NotNull();

            // 必須為 Null
            //name.Null();

            // 不可為空
            //name.NotEmpty();

            // 必須為空
            //name.Empty();

            // 不可相同
            //name.NotEqual("Test Card");

            // 不可相同：也支持 StringComparer
            //name.NotEqual("Test Card", StringComparer.OrdinalIgnoreCase);

            // 不可相同：也可以比較其他欄位（大多驗證器都支援）
            //name.NotEqual(card => card.Type.ToString());

            // 必須相同，其餘用法可參考 NotEqual
            //name.Equal("Blue-Eyes White Dragon");

            // 長度限制，限定１～２００
            //name.Length(1, 200);

            // 最大長度限制
            //name.MaximumLength(200);

            // 最小長度限制
            //name.MinimumLength(0);

            // 數值需低於目標值
            //cost.LessThan(11);

            // 數值需低於或等於目標值
            //cost.LessThanOrEqualTo(10);

            // 數值需高於目標值
            //cost.GreaterThan(0);

            // 數值需高於或等於目標值
            //cost.GreaterThanOrEqualTo(0);

            // 數值需介於兩個目標值之間
            // cost.ExclusiveBetween(0, 11);

            // 數值需介於兩個目標值之間（包含目標值）
            //cost.InclusiveBetween(1, 10);

            // 檢查是否具有指定的位數，例如 (1, 4) = 小數點限１位、總位數限４位
            //this.RuleFor(x => (decimal)x.Cost).ScalePrecision(0, 2);

            // 正則表達式
            //name.Matches(@"^[a-zA-Z-' ]*$");

            // 必須為信箱格式
            //name.EmailAddress();

            // 必須為信用卡格式
            //name.CreditCard();

            // 必須包含在列舉中
            //type.IsInEnum();

            // 必須包含在列舉名稱中
            //name.IsEnumName(typeof(CardType));

            // 指定驗證場景
            //cost.GreaterThan(0).When(card => card.Type is CardType.Monster);

            // 指定驗證場景
            //this.When(card => card.Type is CardType.Monster, () =>
            //{
            //    cost.GreaterThan(0);
            //});
            // .Otherwise(() => { cost.GreaterThan(0); });

            // 最終大絕招：自訂驗證器
            //cost.Must(power => power > 0 && power <= 3000);

            #endregion

            this.RuleFor(card => card.Attack)
            .GreaterThanOrEqualTo(0);

            this.RuleFor(card => card.Health)
                .GreaterThanOrEqualTo(0);

            this.RuleFor(card => card.Cost)
                .GreaterThanOrEqualTo(0);

            this.RuleFor(card => card.Description)
                .NotNull()
                .MaximumLength(30);

            this.RuleFor(card => card.Name)
                .NotEmpty()
                .MaximumLength(15);
        }
    }

    public class EquipmentValidator : AbstractValidator<Equipment> { }
}
